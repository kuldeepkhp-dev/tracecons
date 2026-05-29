// JScript File
//-- Block right click
/*
document.oncontextmenu = function(){return false}
document.ondragstart = function(){return false}
document.onselectstart = function(){return true}
  if(document.layers) {
       window.captureEvents(Event.MOUSEDOWN);
       window.onmousedown = function(e){
           if(e.target==document)return false;
       }
   }
  else {
    document.onmousedown = function(){return false}

	}


document.onkeydown = function(){

if(window.event && window.event.keyCode == 116)
{ 
window.event.returnValue = false;
window.event.cancelBubble = true;
window.event.keyCode = 505;
}
//   if(window.event && window.event.keyCode == 8)
//   	{ 
//   	
//   	return false;
//   	}

	if(window.event && window.event.keyCode == 505)
	{ 
	//alert("Please don't refresh this page.");
	return false;
	}
	 if(window.event.ctrlKey)
	 {
        //alert("Ctrl Key Pressed")
		//	isCtrl = true;
		//	return false
      }
	

}
//end--- 

*/

// Print in New Window

    function displayHTML(printContent)
		{
			var inf = printContent;
			win = window.open("", 'popup', 'toolbar=no,menubar=yes,location=no,status=yes,scrollbars=yes,resizable=yes');
			win.document.write(inf);
		}

//-- End Print

function OpenWindowEdit(URL)
{
	var NewWin = window.open(URL,"EditUserDetails","height=400,width=750,top=200,left=100,resizable=no,scrollbars=1"); 
}

function OpenWindowDelete(URL)
{
	if  (confirm("Are you sure to Delete !"))
		var NwWin = window.open(URL,"DeleteUserDetails","height=175,width=350,top=200,left=100,resizable=no,scrollbars=no"); 
}

function OpenWindowSmall(URL,title)
{
	 var newWin = window.open(URL,title,"menubar=no,toolbar=no,scrollbars=1,resizable=no,height=150,width=430,top=250,left=300"); 
  	 newWin.focus()
}

function OpenWindowBig(URL,title)
{
	 var newWin = window.open(URL, title,"menubar=no,toolbar=no, scrollbars=1,resizable=yes,height="+ (screen.height-10) + ",width=" + (screen.width-10) + ",top=0,left=0"); 
  	 newWin.focus(); 

}




    function convertTomd5()
    {
        
        document.forms[0].ctl00$RegCPH$txtPassword.value=hex_hmac_md5(document.forms[0].ctl00$RegCPH$txtPassword.value,document.forms[0].challenge.value);   
    }    
    function OpenWindow_Chg_Password(URL)
    {
	     var newWin = window.open(URL,"ChangePwd1","menubar=no,toolbar=no,scrollbars=1,resizable=No,height=250,width=430,top=250,left=300"); 
  	     newWin.focus()
    }
    
    function ChangedPwdTomd5()
    {
        if(document.forms[0].txtoldpwd.value!="" || document.forms[0].txtnewpwd.value!=="" ||document.forms[0].txtconfirmpwd.value!="")
        {
        document.forms[0].txtoldpwd.value=hex_hmac_md5(document.forms[0].txtoldpwd.value,document.forms[0].challenge.value);   
        document.forms[0].txtnewpwd.value=hex_hmac_md5(document.forms[0].txtnewpwd.value,document.forms[0].challenge.value);   
        document.forms[0].txtconfirmpwd.value=hex_hmac_md5(document.forms[0].txtconfirmpwd.value,document.forms[0].challenge.value);   
        }
        else
        {
        //alert("All Text fields are mandatory")
        }
    } 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // Testing Page Validation and Message for Confirm & fails
    
    
    
    function checkonblur(idummy)
		 {
			//alert("I am inside the checkblur function");
			a =  "BLQ"
			var residue1 =document.getElementById("ctl00$RegCPH$residue"+idummy);
			var Val = residue1.value;
			if (Val == "")
				{	
					alert("Enter all the Residue Content Value(s)");
					residue1.focus();
					return false;
				}
						
				//Convert .01 to 0.01 ---------
							
				Val1 = Val.substring(0,1)
				
				if(Val1=="." )
				{
					Val2 ="0"+Val
					residue1.value = Val2
					
				}

				//-------------------------------		

					

					if (Val != "BLQ")
					{
						if(isNaN(Val))
						{
							alert("Sorry! Enter Residue Content Value(s) in numeric")
							residue1.focus();
						}
					}
					
					if (Val != "BLQ")
					{
						a = eval(parseFloat(Val))
						
					}

					var Range_EU1 =document.getElementById("ctl00$RegCPH$Range_EU"+idummy);
					var Range_EU = Range_EU1.value;
					
					if (Range_EU!='#')
					{
						EU = eval(parseFloat(Range_EU))
						
					}
					else
					{
						var Range_Lowest1 =document.getElementById("ctl00$RegCPH$Range_Lowest"+idummy);
						var Range_Lowest = Range_Lowest1.value;
						EU = parseFloat(Range_Lowest)
					}
				
					var Range_UK1 =document.getElementById("ctl00$RegCPH$Range_UK"+idummy);
					var Range_UK = Range_UK1.value;
					
					if (Range_UK!='#')
					{
						UK = eval(parseFloat(Range_UK))
					
					}
					else
					{
										
						var Range_Lowest1 =document.getElementById("ctl00$RegCPH$Range_Lowest"+idummy);
						var Range_Lowest = Range_Lowest1.value;
						
						UK =parseFloat(Range_Lowest)
					}
					
					var Range_Netherland1 =document.getElementById("ctl00$RegCPH$Range_NL"+idummy);
					var Range_Netherland = Range_Netherland1.value;
										
					if (Range_Netherland!='#')
					{
						NL = eval(parseFloat(Range_Netherland))
						
					}
					else
					{
						var Range_Lowest1 =document.getElementById("ctl00$RegCPH$Range_Lowest"+idummy);
						var Range_Lowest = Range_Lowest1.value;
						NL =parseFloat(Range_Lowest)
					}

					var Range_Germany1 =document.getElementById("ctl00$RegCPH$Range_GER"+idummy);
					var Range_Germany = Range_Germany1.value;
										
					if (Range_Germany!='#')
					{
						GR = eval(parseFloat(Range_Germany))

					}
					else
					{
					
						var Range_Lowest1 =document.getElementById("ctl00$RegCPH$Range_Lowest"+idummy);
						var Range_Lowest = Range_Lowest1.value;
						GR =parseFloat(Range_Lowest)
						//GR =parseFloat('0.01') 
					}

					if (a != "BLQ")
					{
						if(a > EU || a > UK || a > NL || a > GR)
						{
								
								var residue =document.getElementById("ctl00$RegCPH$residue"+idummy);
								
								residue.style.color='#330000';
								residue.style.backgroundColor='#FF6633';
						}
						else
						{
								var residue =document.getElementById("ctl00$RegCPH$residue"+idummy);
								residue.style.color='#000000';
								residue.style.backgroundColor='#FFFFFF';
						}
					}
					
				
		 }
		
		function  ValidateForm(i)
		{
			var Result="Conforms"
			var Error_flag=false
			var Range_EU_flag=false
			var Range_UK_flag=false
			var Range_Netherland_flag=false
			var Range_Germany_flag=false
			var sErrMsg="";
			
			for(idummy=0;idummy<i;idummy++)
			{
			//alert("alert"+i)
				var a = document.getElementById("ctl00$RegCPH$residue"+idummy);
				var residue = a.value;	
								
				if (residue == "")
				{	
					alert("Enter all the Residue Content Value(s)");
					return false;
				}
							
				Val =	residue
					
					if (Val != "BLQ")
					{
						if (isNaN(Val))
						{
							sErrMsg =  sErrMsg + "- Enter all the Residue Content Value(s) in numeric"
							a.focus();
							
							break
						}
					}

				
				var Range_Lowest1 = document.getElementById("ctl00$RegCPH$Range_Lowest"+idummy);
				var Range_Lowest = Range_Lowest1.value;	

				if((Range_Lowest!="#")&&(Range_Lowest!=""))
				{	

					if (Range_Lowest!= "BLQ")
					{
						
					//---- RANGE_EU --------//
						var Range_EU1 = document.getElementById("ctl00$RegCPH$Range_EU"+idummy);
						var Range_EU = Range_EU1.value;	
						
						if((Range_EU!="#")&&(Range_EU!=""))
									ValEU = Range_EU
							else
									ValEU = Range_Lowest
		
						
						
							if((parseFloat(residue)) > (parseFloat(ValEU)))
									{
											
											Range_EU_flag=true
																						
											var Fail_EU = document.getElementById("ctl00$RegCPH$Fail_EU"+idummy);				
											Fail_EU.value="True";
					//	alert(document.getElementById("Fail_EU"+idummy).value)
					//	return false;				
											Error_flag=true
											Error_Index = idummy
										
									}

							
				
							//---- RANGE_UK --------//
							
							var Range_UK1 = document.getElementById("ctl00$RegCPH$Range_UK"+idummy);
							var Range_UK = Range_UK1.value;	
							
							
							
							if((Range_UK!="#")&&(Range_UK!=""))
									ValUK = Range_UK
							else
									ValUK = Range_Lowest

							  if((parseFloat(residue)) > (parseFloat(ValUK)))
									{
											Range_UK_flag=true
											
											var Fail_UK = document.getElementById("ctl00$RegCPH$Fail_UK"+idummy);					
											Fail_UK.value="True"
											
											Error_flag=true
											Error_Index = idummy

									}
													
							//---- RANGE_NetherLands--------//
							
							var Range_Netherland1 = document.getElementById("ctl00$RegCPH$Range_NL"+idummy);
							var Range_Netherland = Range_Netherland1.value;	
							
							
							if((Range_Netherland!="#")&&(Range_Netherland!=""))
									ValNL = Range_Netherland
							else
									ValNL = Range_Lowest

						
								if((parseFloat(residue))>(parseFloat(ValNL)))
									{
											Range_Netherland_flag=true
											
											var Fail_NL = document.getElementById("ctl00$RegCPH$Fail_NL"+idummy);					
											Fail_NL.value="True"
																						
											Error_flag=true
											Error_Index = idummy
									}
							

							//---- RANGE_Germany--------//
							var Range_Germany1 = document.getElementById("ctl00$RegCPH$Range_GER"+idummy);
							var Range_Germany = Range_Germany1.value;	
							
							if((Range_Germany!="#")&&(Range_Germany!=""))
									ValGER = Range_Germany
							else
									VarGER = Range_Lowest  
						
   							  if((parseFloat(residue))>(parseFloat(ValGER)))
									{
											Range_Germany_flag=true
											
											var Fail_Germany = document.getElementById("ctl00$RegCPH$Fail_Germany"+idummy);					
											Fail_Germany.value="True"
																				
											Error_flag=true
											Error_Index = idummy

									}
					
					}

				}

			} // End of For Loop
			
			
			if(sErrMsg!="")
			{
				alert("The form could not be submited because of the following errors:\n\n" + sErrMsg);
				return false;
			}
			
			
			MessageStr = "";
			ConfirmStr = "";

				
			if(Error_flag)
			{
			
			
					if(Range_EU_flag)
					{
						
						MessageStr="EU"
						
						var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
							Result_EU.value="FAIL"
												
					}
					else
					{
						ConfirmStr="EU"
						var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
							Result_EU.value="PASS"
						
						
					}

					if(Range_UK_flag)
					{
						if (MessageStr == "") 
						{
							MessageStr="UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="FAIL"
							
							
						}
						else
						{
							MessageStr= MessageStr + ",UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="FAIL"
							
																					
						}
					}
					else
					{

						if (ConfirmStr == "") 
						{
							ConfirmStr="UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="PASS"
							
						}		
						else
						{
							ConfirmStr = ConfirmStr + "/UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="PASS"
						}
					}

					if(Range_Netherland_flag)
					{

						if (MessageStr == "") 
						{
							MessageStr="NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="FAIL"
							
						}
						else
						{
							MessageStr= MessageStr + ",NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="FAIL"
							
						}
					}
					else
					{
						if (ConfirmStr == "") 
						{
							ConfirmStr="NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="PASS"
							
						}
						else
						{
							ConfirmStr = ConfirmStr + "/NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="PASS"
							
						}
					}
				
					if(Range_Germany_flag)
					{

						if (MessageStr == "") 
						{
							MessageStr="GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="FAIL"
													
						}
						else
						{
							MessageStr= MessageStr + ",GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="FAIL"
							
						}

					}
					else
					{
						if (ConfirmStr == "") 
						{
							ConfirmStr="GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="PASS"
							
						}
						else
						{
							ConfirmStr = ConfirmStr + "/GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="PASS"
							
						}
					}
				

					Result="Fails"

					if(ConfirmStr == "")
					{
					
					
						ConfirmStr="Fails to meet MRL requirements of EU/UK/NL/GER "
						var Result_Desc = document.getElementById("ctl00$RegCPH$Result_Desc");					
							Result_Desc.value=ConfirmStr
												
						var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
							Result_EU.value="FAIL"
						var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="FAIL"
						var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="FAIL"
						var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="FAIL"
											
					}
					else
					{
				
						ConfirmStr="Conforms to MRL requirements of " + ConfirmStr
						var Result_Desc = document.getElementById("ctl00$RegCPH$Result_Desc");					
							Result_Desc.value=ConfirmStr
						
					}
					
					
					var Result1 = document.getElementById("ctl00$RegCPH$Result");					
						Result1.value=Result
					
				
					if(!confirm(" According to the residue content value(s) entered by you , the test report fails for "+MessageStr+".\n(Residue content value exceeds the MRL value) \n Do you want to continue?" ))
					{
						//document.TestDetails.residue[Error_Index].focus()
						var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
							SaveClick.value="Cancel"
							return false;		
								
					}
					else
					{
						var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
							SaveClick.value="Save"
							return true;		
					}
			}
			else
			{
			
				Conform="Conforms to MRL requirements of EU/UK/NL/GER"
				var Result_Desc = document.getElementById("ctl00$RegCPH$Result_Desc");					
					Result_Desc.value=Conform
				
				
				var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
					Result_EU.value="PASS"
				var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
					Result_UK.value="PASS"
				var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
					Result_NL.value="PASS"
				var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
					Result_Ger.value="PASS"
				
				
				Result="Conforms"	
				
				var Result1 = document.getElementById("ctl00$RegCPH$Result");					
					Result1.value=Result
						
				
				if(!confirm(" According to the residue content value(s) entered by you , the test report conforms.\n(Residue content values are below the prescribed MRL values) \n Do you want to continue?" ))
				{
					var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
							SaveClick.value="Cancel"
					//alert(SaveClick.value)
					return false;		
				}
				else
				{
					var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
						SaveClick.value="Save"
						//alert(SaveClick.value)
					return true;		
				}
			}

	}
	
	// Validation for temporary save
	
		function  ValidateFormTemp(i)
		{
			var Result="Conforms"
			var Error_flag=false
			var Range_EU_flag=false
			var Range_UK_flag=false
			var Range_Netherland_flag=false
			var Range_Germany_flag=false
			var sErrMsg="";
			
			for(idummy=0;idummy<i;idummy++)
			{
			//alert("alert"+i)
				var a = document.getElementById("ctl00$RegCPH$residue"+idummy);
				var residue = a.value;	
								
				if (residue == "")
				{	
					alert("Enter all the Residue Content Value(s)");
					return false;
				}
							
				Val =	residue
					
					if (Val != "BLQ")
					{
						if (isNaN(Val))
						{
							sErrMsg =  sErrMsg + "- Enter all the Residue Content Value(s) in numeric"
							a.focus();
							
							break
						}
					}

				
				var Range_Lowest1 = document.getElementById("ctl00$RegCPH$Range_Lowest"+idummy);
				var Range_Lowest = Range_Lowest1.value;	

				if((Range_Lowest!="#")&&(Range_Lowest!=""))
				{	

					if (Range_Lowest!= "BLQ")
					{
						
					//---- RANGE_EU --------//
						var Range_EU1 = document.getElementById("ctl00$RegCPH$Range_EU"+idummy);
						var Range_EU = Range_EU1.value;	
						
						if((Range_EU!="#")&&(Range_EU!=""))
									ValEU = Range_EU
							else
									ValEU = Range_Lowest
		
						
						
							if((parseFloat(residue)) > (parseFloat(ValEU)))
									{
											
											Range_EU_flag=true
																						
											var Fail_EU = document.getElementById("ctl00$RegCPH$Fail_EU"+idummy);				
											Fail_EU.value="True";
					//	alert(document.getElementById("Fail_EU"+idummy).value)
					//	return false;				
											Error_flag=true
											Error_Index = idummy
										
									}

							
				
							//---- RANGE_UK --------//
							
							var Range_UK1 = document.getElementById("ctl00$RegCPH$Range_UK"+idummy);
							var Range_UK = Range_UK1.value;	
							
							
							
							if((Range_UK!="#")&&(Range_UK!=""))
									ValUK = Range_UK
							else
									ValUK = Range_Lowest

							  if((parseFloat(residue)) > (parseFloat(ValUK)))
									{
											Range_UK_flag=true
											
											var Fail_UK = document.getElementById("ctl00$RegCPH$Fail_UK"+idummy);					
											Fail_UK.value="True"
											
											Error_flag=true
											Error_Index = idummy

									}
													
							//---- RANGE_NetherLands--------//
							
							var Range_Netherland1 = document.getElementById("ctl00$RegCPH$Range_NL"+idummy);
							var Range_Netherland = Range_Netherland1.value;	
							
							
							if((Range_Netherland!="#")&&(Range_Netherland!=""))
									ValNL = Range_Netherland
							else
									ValNL = Range_Lowest

						
								if((parseFloat(residue))>(parseFloat(ValNL)))
									{
											Range_Netherland_flag=true
											
											var Fail_NL = document.getElementById("ctl00$RegCPH$Fail_NL"+idummy);					
											Fail_NL.value="True"
																						
											Error_flag=true
											Error_Index = idummy
									}
							

							//---- RANGE_Germany--------//
							var Range_Germany1 = document.getElementById("ctl00$RegCPH$Range_GER"+idummy);
							var Range_Germany = Range_Germany1.value;	
							
							if((Range_Germany!="#")&&(Range_Germany!=""))
									ValGER = Range_Germany
							else
									VarGER = Range_Lowest  
						
   							  if((parseFloat(residue))>(parseFloat(ValGER)))
									{
											Range_Germany_flag=true
											
											var Fail_Germany = document.getElementById("ctl00$RegCPH$Fail_Germany"+idummy);					
											Fail_Germany.value="True"
																				
											Error_flag=true
											Error_Index = idummy

									}
					
					}

				}

			} // End of For Loop
			
			
			if(sErrMsg!="")
			{
				alert("The form could not be submited because of the following errors:\n\n" + sErrMsg);
				return false;
			}
			
			
			MessageStr = "";
			ConfirmStr = "";

				
			if(Error_flag)
			{
			
			
					if(Range_EU_flag)
					{
						
						MessageStr="EU"
						
						var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
							Result_EU.value="FAIL"
												
					}
					else
					{
						ConfirmStr="EU"
						var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
							Result_EU.value="PASS"
						
						
					}

					if(Range_UK_flag)
					{
						if (MessageStr == "") 
						{
							MessageStr="UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="FAIL"
							
							
						}
						else
						{
							MessageStr= MessageStr + ",UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="FAIL"
							
																					
						}
					}
					else
					{

						if (ConfirmStr == "") 
						{
							ConfirmStr="UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="PASS"
							
						}		
						else
						{
							ConfirmStr = ConfirmStr + "/UK"
							var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="PASS"
						}
					}

					if(Range_Netherland_flag)
					{

						if (MessageStr == "") 
						{
							MessageStr="NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="FAIL"
							
						}
						else
						{
							MessageStr= MessageStr + ",NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="FAIL"
							
						}
					}
					else
					{
						if (ConfirmStr == "") 
						{
							ConfirmStr="NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="PASS"
							
						}
						else
						{
							ConfirmStr = ConfirmStr + "/NL"
							var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="PASS"
							
						}
					}
				
					if(Range_Germany_flag)
					{

						if (MessageStr == "") 
						{
							MessageStr="GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="FAIL"
													
						}
						else
						{
							MessageStr= MessageStr + ",GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="FAIL"
							
						}

					}
					else
					{
						if (ConfirmStr == "") 
						{
							ConfirmStr="GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="PASS"
							
						}
						else
						{
							ConfirmStr = ConfirmStr + "/GER"
							var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="PASS"
							
						}
					}
				

					Result="Fails"

					if(ConfirmStr == "")
					{
					
					
						ConfirmStr="Fails to meet MRL requirements of EU/UK/NL/GER "
						var Result_Desc = document.getElementById("ctl00$RegCPH$Result_Desc");					
							Result_Desc.value=ConfirmStr
												
						var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
							Result_EU.value="FAIL"
						var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
							Result_UK.value="FAIL"
						var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
							Result_NL.value="FAIL"
						var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
							Result_Ger.value="FAIL"
											
					}
					else
					{
				
						ConfirmStr="Conforms to MRL requirements of " + ConfirmStr
						var Result_Desc = document.getElementById("ctl00$RegCPH$Result_Desc");					
							Result_Desc.value=ConfirmStr
						
					}
					
					
					var Result1 = document.getElementById("ctl00$RegCPH$Result");					
						Result1.value=Result
					
				
					if(!confirm(" According to the residue content value(s) entered by you , the test report fails for "+MessageStr+".\n(Residue content value exceeds the MRL value) \n Do you want to continue?" ))
					{
						//document.TestDetails.residue[Error_Index].focus()
						var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
							SaveClick.value="Cancel"
							return false;		
								
					}
					else
					{
						var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
							SaveClick.value="Save"
							return true;		
					}
			}
			else
			{
			
				Conform="Conforms to MRL requirements of EU/UK/NL/GER"
				var Result_Desc = document.getElementById("ctl00$RegCPH$Result_Desc");					
					Result_Desc.value=Conform
				
				
				var Result_EU = document.getElementById("ctl00$RegCPH$Result_EU");					
					Result_EU.value="PASS"
				var Result_UK = document.getElementById("ctl00$RegCPH$Result_UK");					
					Result_UK.value="PASS"
				var Result_NL = document.getElementById("ctl00$RegCPH$Result_NL");					
					Result_NL.value="PASS"
				var Result_Ger = document.getElementById("ctl00$RegCPH$Result_Ger");					
					Result_Ger.value="PASS"
				
				
				Result="Conforms"	
				
				var Result1 = document.getElementById("ctl00$RegCPH$Result");					
					Result1.value=Result
						
				
				if(!confirm(" According to the residue content value(s) entered by you , the test report conforms.\n(Residue content values are below the prescribed MRL values) \n Do you want to continue?" ))
				{
					var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
							SaveClick.value="Cancel"
					return false;		
				}
				else
				{
					var SaveClick = document.getElementById("ctl00$RegCPH$SaveClick");					
						SaveClick.value="Save"
					return true;		
				}
			}

	}
	
	//====== testing Function End Here