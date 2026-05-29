// JScript File
 
    
    
    
    
    ///= for agmark inspection
    
    
     function validate_form()
				{
				
					var ResultFlag = true
					var ReasonForFailure = ""
					var ReasonForFailurePrefix = "Agmark Inspection Report fails because of " 

					//----------------- Cleanliness-------------------------//
					if (document.getElementById("ctl00$RegCPH$ddlClinliness").value =="Unclean")
					{
					
					
						ResultFlag = false
						ReasonForFailure  = "-- Cleanliness :- Unclean \n"
					} 

				//	alert("ResultFlag is " + ResultFlag)
					
					
					//----------------- End of Cleanliness-------------------------//

				// -----------------------Soundness ---------------------
					if (document.getElementById("ctl00$RegCPH$ddlSoundNess").value =="Unsound")
					{
					
						ResultFlag = false

						if (ReasonForFailure != "") 
						{
							ReasonForFailure  += "-- Soundness :- Unsound \n"
						}
						else
						{
							ReasonForFailure  = "-- Soundness :- Unsound \n"
						}
					}

					
				//	----------------- Foreign matter ----------------
					if (document.getElementById("ctl00$RegCPH$ddlForiegnMatter").value =="Visible")
					{
						ResultFlag = false

						if (ReasonForFailure != "") 
						{
							ReasonForFailure  += "-- Foreign Matter :- Visible \n"
						}
						else
						{
							ReasonForFailure  = "-- Foreign Matter :- Visible \n"
						}
					}
					
				//	------------Pests---------- 	
					if (document.getElementById("ctl00$RegCPH$ddlPests").value =="Present")
						{
						
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Pest :- Present \n"
							}
							else
							{
								ReasonForFailure  = "-- Pest :- Present \n "
							}
						}
					
				//	------------General Appearence --------- 	
					if (document.getElementById("ctl00$RegCPH$ddlGenAppear").value =="Not Appropriate")
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- General Appearence :- Not Appropriate \n"
							}
							else
							{
								ReasonForFailure  = "-- General Appearence :- Not Appropriate \n"
							}
						}

				//	------------Damage Caused by pests or disease  --------- 	
					if (document.getElementById("ctl00$RegCPH$ddlDamage").value =="Yes")
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Damage Caused by pests :- disease is Yes \n"
							}
							else
							{
								ReasonForFailure  = "-- Damage Caused by pests :- disease is Yes \n"
							}
						}

				//	------------Handling Conditions   --------- 	
					if (document.getElementById("ctl00$RegCPH$ddlHandlingCodn").value =="Cannot")
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Handling Conditions :- Cannot withstand transportation  \n"
							}
							else
							{
								ReasonForFailure  = "-- Handling Conditions :- Cannot withstand transportation  \n"
							}
						}

				//	------------external Moisture  --------- 	
					if (document.getElementById("ctl00$RegCPH$ddlAbExtMoisture").value =="Present")
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- External Moisture :- Present \n"
							}
							else
							{
								ReasonForFailure  = "-- External Moisture :- Present \n"
							}
						}

				//	------------ Foreign smell / taste --------- 	
					if (document.getElementById("ctl00$RegCPH$ddlSmell").value =="Present")
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Foreign Smell / Taste :- Present \n"
							}
							else
							{
								ReasonForFailure  = "-- Foreign Smell / Taste :- Present \n"
							}
						}

						
				//	------------ Damage Caused by high / low temperature --------- 	
					if (document.getElementById("ctl00$RegCPH$ddltemperature").value =="Damage")
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Damage Caused by high / low temperature :- Yes \n"
							}
							else
							{
								ReasonForFailure  = "-- Damage Caused by high / low temperature :- Yes \n "
							}
						}

				//	------------ Visible traces of moulds  --------- 	
					if (document.getElementById("ctl00$RegCPH$ddlMpoulds").value =="Present")
						{
						
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Visible traces of moulds :- Present \n"
							}
							else
							{
								ReasonForFailure  = "-- Visible traces of moulds :- Present \n"
							}
						}

				//	------------ Condition of Berries  --------- 	
						var berries1 = document.getElementById("ctl00$RegCPH$ddlBeryCond1").value
						
						var berries2 = document.getElementById("ctl00$RegCPH$ddlberyCond2").value

					if ((berries1 != "Intact") ||(berries2 != "Developed"))
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Condition of Berries should be Intact and Developed  \n"
							}
							else
							{
								ReasonForFailure  = "-- Condition of Berries should be Intact and Developed \n"
							}
						}
						
				//	------------Total Soluble Solids  ---------
					var TSS = document.getElementById("ctl00$RegCPH$txtSoluble").value
					//alert(TSS)
					if (TSS < 16)
						{
						
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Less than mimimum Brix degree (16 degree) \n"
							}
							else
							{
								ReasonForFailure  += "-- Less than mimimum Brix degree (16 degree) \n"
							}
						}

				//	------------ Sugar/Acid Ratio   ---------
					var Sugar = document.getElementById("ctl00$RegCPH$txtsugar").value
					var acid = document.getElementById("ctl00$RegCPH$txtAcid").value
					//alert(TSS)
					if ((Sugar < 20)|| (acid < 1))
						{
							ResultFlag = false

							if (ReasonForFailure != "") 
							{
								ReasonForFailure  += "-- Less than mimimum Sugar/Acid Ratio \n"
							}
							else
							{
								ReasonForFailure  += "-- Less than mimimum Sugar/Acid Ratio \n "
							}
						}
					


					if(ResultFlag == false)   // it is failed 
					{
						document.getElementById("ctl00$RegCPH$RecommendedYN").value = "N"    //not recommended
						document.getElementById("ctl00$RegCPH$Not_Recommended_remarks").value = ReasonForFailurePrefix + ReasonForFailure
					}
					else
					{
						document.getElementById("ctl00$RegCPH$Not_Recommended_remarks").value = "It Satisfies all conditions of Quality Parameters"
						document.getElementById("ctl00$RegCPH$RecommendedYN").value = "Y"   //recommended
					}

					
					//alert("ReasonForFailure is \n\n  " + ReasonForFailure)
					//alert(objFrmMain.RecommendedYN.value)
					//alert(objFrmMain.Not_Recommended_remarks.value)
					//alert("ResultFlag is " + ResultFlag)

					if(ResultFlag == false)  //it is failed 
						{
							if(confirm("Agmark Inspection Report is Not Recommended based on the values entered by you.\n\n" + ReasonForFailure  +" \n Do you want to proceed?"))
								return true
							else	
								return false
						}
						else
						{
							if(confirm("Agmark Inspection Report is Recommended based on the values entered by you.\n Do you want to proceed?"))
								return true
							else	
								return false
						}
					
					
				}
				
				///-- end agmark
				
				
				
				
// -- hint Script
function addLoadEvent(func) {
  var oldonload = window.onload;
  if (typeof window.onload != 'function') {
    window.onload = func;
  } else {
    window.onload = function() {
      oldonload();
      func();
    }
  }
}

function prepareInputsForHints() {
	var inputs = document.getElementsByTagName("input");
	for (var i=0; i<inputs.length; i++){
		// test to see if the hint span exists first
		if (inputs[i].parentNode.getElementsByTagName("span")[0]) {
			// the span exists!  on focus, show the hint
			inputs[i].onfocus = function () {
				this.parentNode.getElementsByTagName("span")[0].style.display = "inline";
			}
			// when the cursor moves away from the field, hide the hint
			inputs[i].onblur = function () {
				this.parentNode.getElementsByTagName("span")[0].style.display = "none";
			}
		}
	}
	// repeat the same tests as above for selects
	var selects = document.getElementsByTagName("select");
	for (var k=0; k<selects.length; k++){
		if (selects[k].parentNode.getElementsByTagName("span")[0]) {
			selects[k].onfocus = function () {
				this.parentNode.getElementsByTagName("span")[0].style.display = "inline";
			}
			selects[k].onblur = function () {
				this.parentNode.getElementsByTagName("span")[0].style.display = "none";
			}
		}
	}
}
addLoadEvent(prepareInputsForHints);
/// end hint scripts


function Open_GenerateReport_Window(URL)
	{
		var newWin = window.open(URL, "GenerateReport","menubar=no,toolbar=no, scrollbars=yes,resizable=yes,height=600,width=750,top=100,left=150,status=1"); 
		newWin.focus()
	}
function ForwardOpenWindow(URL)
{
		if(confirm("Have you checked all the Agmark Inspection Report(s) \n Do you want to proceed?"))
		{
			//return true
			var newWin = window.open(URL,"Forward","menubar=no,toolbar=yes, scrollbars=1,resizable=yes,height="+ (screen.height-10) + ",width=" + (screen.width-10) + ",top=0,left=0"); 
			newWin.focus()
		}
			
		

}