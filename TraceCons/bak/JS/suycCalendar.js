    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	    suycCalendar class for JavaScript
	    © 2000-2001 Darren. J. Neimke - send comments to:
	    darren@flws.com.au -or- showusyourcode@hotmail.com
	    
	    Version:    1.1
        Created:    18-Jul-2001
        
            Constructor:
            -----------------
            var objCalendar = new suycCalendar([month(Int)], [year(Int)])
            ________________________________________________________________________
            
            Pubic Method Selectors:
            ---------------------------------
            BuildCalendar           - Renders a new calendar with a default of current month.
            goToCurrent             - Renders the calendar to the current month.
            toggleCalendar ( int )  - int = number of months to toggle by.
            show                     - sets the visibility of the Canvass to visible
            hide                      - sets the visibility of the Canvass to not visible
            moveTo                 - accepts x,y as pixels moves the canvass to that position
            bindToElement           - Not yet implemented.
            
            Properties Exposed:
            ---------------------------
            hasEvents   (type: Boolean) - if true then interface raises events.
            posX          allows the user to set the left location (the number of pixels from the left edge of the browser window). 
            posY          allows the user to set the top location (the number of pixels from the top edge of the browser window). 
            
            Notes:
            ---------
            If hasEvents is set to True then you need to implement the following event handlers:
                - clickhandler (d,m,y)   - receives the event thrown by the user clicking on a day/date
                - toggleCalendar (i)      - receives the event thrown by the user clicking on << or >>
                - toggleCurrent ()        - receives the event thrown by the user clicking on [ Today ]
                
            Calendar also exposes the following CSS classes:
                - calCalendar           : The base style for the main TABLE
                - calClickable           : Refers to the <<, [ TODAY ], and >> navigation controls at the base of the calendar
                - calClickable_hover  : The onMouseOver state of a calendar date
                - calTitleBar            : the Class of the Title bar
                - calDay                 : The CSS Class of a regular day
                - calDayCurrent       : The CSS Class of the Current day
        
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
                
        Version:    2.0
        Modified:   28-Sep-2001
        Release Notes:
        1.  Added functionality to customize how the current Day is displayed.
                - added DayStyle Enums
                - added Public curDayStyle Property
        2.  Moved Navigator Panel to private String g_calNavPanel
        3.  Added public NavAtTop Property which determines whether the Navigator Panel is 
            displayed at top of calendar or bottom
        4.  Consolidated handling of all positioning of Calendar to the _positionCanvass method
           
            
        Enjoy!!

*****************************************************************************/


/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
				Constants used in the class
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    // Fonts Styles
    var cc_CELL_NORMAL_COLOR   = "#ffffff" ;        // Background color of a cell on a normal day
    var cc_CELL_SELECTED_COLOR   = "Blue" ; // Background color of a cell on the current day
    var cc_FONT_NORMAL_COLOR   = "#000000" ;  // Cell font color on a normal day
    var cc_FONT_SELECTED_COLOR   = "#ffffff" ;    // Cell font color on the current day
    var cc_FONT_FAMILY   = "Verdana, Arial, Helvetica, Sans Serif" ;
    var cc_FONT_NORMAL_SIZE   = "1" ;                 // Cell font size on a normal day
    var cc_FONT_SELECTED_SIZE   = "3" ;              // Cell font size on the current day
    
    var cc_CURRENT_DAY_STYLE = "calDayCurrent" ;
    var cc_NORMAL_DAY_STYLE = "calDay" ;
    
    // Cell specific settings
    var cc_CELL_WIDTH  = 20 ;
    var cc_CELL_HEIGHT = 20 ;
    
    // Table specific settings
    var cc_TABLE_WIDTH  = (7*cc_CELL_WIDTH) ;
    var cc_NORMAL_STYLE = "calCalendar" ;
    var cc_NORMAL_BG_COLOR = "#d4d0c8"
        	
	
function suycCalendar( m, y )
{
    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
				Initialize Calendar Control
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
    if (typeof(_calendar_prototype_called) == 'undefined')
    {
        _calendar_prototype_called = true ;
        
        // Object methods
        this.BuildCalendar = _create ;
        this.createCanvass = _createCanvass ;
        this.showCalendar = _showCalendar ;
        this.goToCurrent = _goToCurrent ;
        this.toggleCalendar = _toggleCalendar ;
        this.moveTo = _positionCanvass ;
        this.hide = _hide ;
        this.show = _show ;
        this.init = _init ;
        this.renderNavBar = _renderNavBar ;
        this.GetDay = _getDayString ;
        
        // The Navigator Panel used to toggle between Months if hasEvents is switched to true
        g_calNavPanel = "<tr>" ;
        g_calNavPanel += "<td colspan=2 align=left>" ;
        g_calNavPanel += "<A HREF=\"javascript:  ;\" onClick='toggleCalendar(-1) ; return false ;' CLASS='calClickable'  onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\" TITLE='Previous Month' /><FONT COLOR='Black'>&lt;&lt;</FONT></A>" ;
        g_calNavPanel += "</td>" ;
        g_calNavPanel += "<td colspan=3 align=center>" ;
        g_calNavPanel += "<A HREF=\"javascript:  ;\" onClick='toggleCurrent() ; return false ;' CLASS='calClickable'  onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\" TITLE='Current Month' /><FONT COLOR='Black'>[ Today ]</FONT></A>" ;
        g_calNavPanel += "</td>" ;
        g_calNavPanel += "<td colspan=2 align=right>" ;
        g_calNavPanel += "<A HREF=\"javascript:  ;\" onClick='toggleCalendar(1) ; return false ;' CLASS='calClickable'  onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\" TITLE='Next Month' /><FONT COLOR='Black'>&gt;&gt;</FONT></A>" ;
        g_calNavPanel += "</td>" ;
        g_calNavPanel += "</tr>" ;
        
        // Object properties
        this.name = 'default' ;
        this.rowBGColor = cc_NORMAL_BG_COLOR ;
        this.currentDay = 0 ;
        this.currentMonth = 0 ;
        this.currentYear = 0 ;
        this.visible = false ;
        this.posX = 10 ;
        this.posY = 10 ;
        this.isIE4 = new Boolean ;
        this.isNav4 = new Boolean ;
        this.NavAtTop = true ;
        
        // If you set hasEvents fo FALSE then the calendar face is dumbed out.
        this.hasEvents = true ;
        
        this.canvass = new Object ;           // The DIV || LAYER that we display the calendar on.
        this.bindToElement = new Object ;     // Bind to an ELEMENT on the page.
        
        // Array of day names
        this.days = new Array("Sunday", "Monday", "Tuesday", "Wednesday","Thursday", "Friday", "Saturday") ;
        // Array of month names
        this.months = new Array("January", "February", "March", "April", "May","June", "July", "August", "September", "October", "November", "December") ;
        // Array of total days in each month
        this.totalDays = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31) ;
        
        // Call the Initialize() event.
        this.init( m, y ) ;
    }
}


// Called on initialization of the Class
function _init( m, y )
{
    if ( parseInt( navigator.appVersion.charAt(0) ) >= 4 )
    // Browser check.
    {
        this.isNav4 = ( navigator.appName == "Netscape" ) ? true : false ;
        this.isIE4 = ( navigator.appName.indexOf( "Microsoft" ) != -1 ) ? true : false ;
    }
    
    // Populate the current Day|Month|Year properties
    var objDate = new Date() ;
    this.currentDay = objDate.getDate() ;
    this.currentMonth = objDate.getMonth() ; 
    var curYear = objDate.getYear() ; 
    this.currentYear = (curYear < 1000) ? curYear + 1900 : curYear ; 
    
    /* 
        The constructor optionally accepts m && y parameters
        if none are supplied, the calendar defaults to the current
        month 
    */
    this.month = m || this.currentMonth ;
    this.year = y || this.currentYear ;
    
    // Create the canvass that we will be displaying the calendar on
    this.createCanvass( ) ;
}


// Called on initialization of the Class to create the acutal DIV|LAYER Object
function _createCanvass( )
{
    if (this.isNav4) 
    { 
        this.canvass = new Layer(200) ;
    }
    else if (this.isIE4)
    {
        var objDiv = document.createElement("<DIV STYLE='position: absolute'>") ;
        document.body.appendChild ( objDiv ) ;
        this.canvass = objDiv ;
    }
    
    this.moveTo( this.posX, this.posY ) ;
}


// 
function _positionCanvass( x, y )
{
    // if either x or y were not supplied, default to the current settings.
    if( x==null || y==null ) 
    {
        x=this.posX ; 
        y=this.posY ; 
    }
    
    if( isNaN( x ) || isNaN( y ) )
    {
        alert('You can only enter numbers for the x/y co-ordinates') ;
        return ;
    }
    
    // apply Positioning
    if ( this.isNav4 ) 
    { 
        this.canvass.left = this.posX = x ;
        this.canvass.top = this.posY = y ;
    }
    else if ( this.isIE4 )
    {
        this.canvass.style.left = this.posX = x ;
        this.canvass.style.top = this.posY = y ;
    }
}


// This function sets visibility of the canvass to Visible.
function _show( )
{
    if(this.isNav4)
    {
        this.canvass.visibility = 'show' ;
    }
    else if (this.isIE4)
    {
        this.canvass.style.visibility = 'visible' ;
    }
    
    this.moveTo( this.posX, this.posY ) ;
    this.visible = true ; 
}


// This function hides the objects canvass.
function _hide( )
{
    if(this.isNav4)
    {
        this.canvass.visibility = 'hide' ;   
    }
    else if (this.isIE4)
    {
        this.canvass.style.visibility = 'hidden' ;
    }
    this.visible = false ;
}

// Renders the calendar
function _showCalendar ( s )
{
    if( this.isNav4 )
    {
        this.canvass.document.open( ) ;
        this.canvass.document.writeln( s ) ;
        this.canvass.document.close( ) ;
    }
    else if ( this.isIE4 )
    {
        this.canvass.innerHTML = s ;
    }
    
    this.show( ) ;
}


// Toggles the Calendar to the current Month/Year
function _goToCurrent()
{
    this.year = this.currentYear ;
    this.month = this.currentMonth ;
    this.BuildCalendar() ;
}


// Responsible for deciding where and what type of NavBar is produced
// arguments: pos = 'top' or 'bottom'
function _renderNavBar( pos )
{
    if( pos == 'top' && this.NavAtTop && this.hasEvents )
    {
        return g_calNavPanel ;
    }
    else if( pos == 'bottom' && !(this.NavAtTop) && this.hasEvents )
    {
        return g_calNavPanel ;
    }
    else return '' ;
}


// Toggles the Calendar by +/- 1 Month
function _toggleCalendar(n)
{
    if((this.month + n) < 0)
    {
        this.month = 11 ;
        -- this.year ;
    }
    else if((this.month + n) >= 12) 
    { 
        this.month = 0 ; 
        ++ this.year ; 
    }
    else
    {
        this.month = this.month + n ;
    }
    
    this.BuildCalendar() ;
}


// Create and Display Calendar.
function _create()
{
    // Counters to count rows and days 
    var rowCount = 0 ;
    
    var sOut = new String ;   // String to store calendar output.
    
    // Leap year correction
    if (this.year % 4 == 0 && (this.year % 100 != 0 || this.year % 400 == 0)) {
    	this.totalDays[1] = 29 ;
    }
    
    // Get the first and last Day numbers of the month being fetched
    var objDate = new Date( this.year, this.month, 1 ) ;
    var firstDayOfMonth = objDate.getDay() ;
    objDate.setDate(31) ;
    var lastDayOfMonth = objDate.getDay() ;
    objDate = null ;
    
    sOut = "<TABLE BORDER=0 CELLPADDING=1 CELLSPACING=0 CLASS=" + cc_NORMAL_STYLE + ">" ;
    
    /* CREATE THE CELLS FOR THE TABLE HEADER */
    sOut += "<TR CLASS='calTitleBar' HEIGHT=" + cc_CELL_HEIGHT + ">"
        + "<TD COLSPAN=6 ALIGN=left>"
        + "<FONT FACE='" + cc_FONT_FAMILY + "'"
		+ " SIZE='" + cc_FONT_NORMAL_SIZE  + "'"
		+ " COLOR='" + cc_FONT_SELECTED_COLOR + "'"
		+ " ><STRONG>" + this.months[this.month] + " " + this.year + "</STRONG></FONT></TD>" 
        + "<TD ALIGN='right'><A HREF=\"javascript:  ;\" ONCLICK='calClose() ; return false ;' TITLE='Close'><IMG SRC='../images/x.gif' border='1'></A></TD>" ;
        + "</TR>" ;
    
    // Test for Calendar NavBar.
    sOut += this.renderNavBar ( 'top' ) ;
   
    
    /* CREATE THE CELLS FOR THE DAY NAMES ie: MON, TUE... */
    sOut += "<TR>" ;
    for (x=0; x<7; x++)
    {
        // Call the method to create the cell contents
        sOut += this.GetDay ( this.days[x].substring(0,3), false ) ;
    }
    sOut += "</TR>" ;

    /* START OF CALENDAR BODY */
    sOut += "<TR CLASS='bodyMain'>" ;
    
    for (x=1; x<=firstDayOfMonth; x++)
    {
        /* pad the blank days at the beginning of the month. */
        rowCount++ ;
        sOut += this.GetDay ( "&nbsp;", false ) ;
    }
    
    /* CREATE THE CELLS FOR EACH DAY IN THE CURRENT MONTH */
    var dayCount = 1 ;
    
    while (dayCount <= this.totalDays[this.month])
    {
    	/* Display new row after each 7 day block.  */
    	if (rowCount % 7 == 0)
    	{
    	    sOut += "</TR>\n<TR>" ;
    	}
    	
    	// Call the method to create the cell contents
    	sOut += this.GetDay ( dayCount, true ) ;
    	++rowCount ;
    	++dayCount ;
    }

    while ( rowCount % 7 != 0 ) {
        /* pad the blank days at the end of the month. */
        ++rowCount ;
       sOut += this.GetDay ( "&nbsp;", false ) ;
    }
    sOut += "</tr>" ;
    // End of BODY
    
    sOut += this.renderNavBar ( 'bottom' ) ;
    
    sOut += "</TABLE>" ;
    
    // Render the calendar
    this.showCalendar ( sOut ) ;
}


/*
    Responsible for displaying a Cell on the calendar face
*/
function _getDayString ( dayNum, isDay )
{
    var blnIsCurrentMonth = ( this.year == this.currentYear && this.month == this.currentMonth ) ;
    var blnIsCurrentDay = ( blnIsCurrentMonth && ( dayNum == this.currentDay ) ) ;
    
    if (blnIsCurrentDay) 
    {
        thisCellBGColor = cc_CELL_SELECTED_COLOR ;
		thisCellFontColor = cc_FONT_SELECTED_COLOR ;
		thisCellFontSize = cc_FONT_SELECTED_SIZE ;
		thisCellClassName = cc_CURRENT_DAY_STYLE ;
    }
    else
    {
        thisCellBGColor = cc_CELL_NORMAL_COLOR ;
		thisCellFontColor = cc_FONT_NORMAL_COLOR ;
		thisCellFontSize= cc_FONT_NORMAL_SIZE ;
		thisCellClassName = cc_NORMAL_DAY_STYLE ;
    }
    
    var tmpLinkStart = '' ;
	var tmpLinkEnd = '' ;
	var tmpCellOuter = '' ;
	
	// Display Cell as link ??
    if( isDay )
    {
        tmpCellOuter = "<TD VALIGN=top" 
	    + " WIDTH=" + cc_CELL_WIDTH 
	    + " HEIGHT=" + cc_CELL_HEIGHT 
	    + " BGCOLOR=" + thisCellBGColor
	    + " CLASS=" + thisCellClassName + " onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className='" + thisCellClassName + "';\">" ;
    
        tmpLinkStart = "<A HREF=\"javascript:  ;\"" ;
        if ( this.hasEvents && isDay ) 
        {
            tmpLinkStart += " ONCLICK='clickhandler(" + dayNum + "," + this.month + "," + this.year + ") ; '" ;
        }
        tmpLinkStart += " CLASS='calClickable'>" ;
    
        tmpLinkEnd  = "</A>" ;
    }
    else
    {
        tmpCellOuter = "<TD VALIGN=top" 
	    + " WIDTH=" + cc_CELL_WIDTH 
	    + " HEIGHT=" + cc_CELL_HEIGHT 
	    + " BGCOLOR=" + thisCellBGColor
	    + " CLASS=" + thisCellClassName + ">" ;
    }
    
    var tmpCellInner = "<FONT"
		+ " FACE='" + cc_FONT_FAMILY  + "'"
		+ " SIZE='" + thisCellFontSize  + "'"
		+ " COLOR='" + thisCellFontColor + "'"
		+ " >" + dayNum + "</FONT>" ;
		    
    return tmpCellOuter + tmpLinkStart + tmpCellInner + tmpLinkEnd + "</TD>\n" ;
}

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			End Of suycCalendar Class
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */