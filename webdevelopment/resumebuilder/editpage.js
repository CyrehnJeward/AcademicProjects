const btnLogin = document.getElementById("btnLogout");


//#region //sessionLogout
btnLogin.onclick = function(){
var lsdUser = "";
var lsdPass = "";
for(let x = 0; x < sessionStorage.length; x++){
    const key = sessionStorage.key(x);
    var temp = key.substr(0,3);
    if(temp == "lsd"){
        lsdUser = key;
        lsdPass = sessionStorage.getItem(key);
        sessionRemove(lsdUser);
        window.location.href = "home.html";
        edittedName.innerHTML = txtName.value;
        }
    }
}

function sessionRemove(user){
    sessionStorage.removeItem(user)
}
//#endregion
// HELLO MAN

//#region HEADER SECTION
const headerName = document.getElementById("headerName");
const headerAddress = document.getElementById("headerAddress");
const headerPhone = document.getElementById("headerPhone");
const headerEmail = document.getElementById("headerEmail");
const headerJobName = document.getElementById("headerJobName");

const textName = document.getElementById("textName");
const textAddress = document.getElementById("textAddress");
const textPhone = document.getElementById("textPhone");
const textEmail = document.getElementById("textEmail");
const textJobName = document.getElementById("textJobName");

const btnHeadName = document.getElementById("btnHeaderName");
const btnHeadAddress = document.getElementById("btnHeaderAddress");
const btnHeadPhone = document.getElementById("btnHeaderPhone");
const btnHeadEmail = document.getElementById("btnHeaderEmail");
const btnJobName = document.getElementById("btnJobName");

const btnImage = document.getElementById("btnHeaderImage");
// var textPImage = document.getElementById("PImage").files[0].name; 

const btnRemove = document.getElementById("btnRemove");

// function Remove(){
//     var key = document.getElementById("txtRemove1");
//     var key2 = document.getElementById("txtRemove2");
//     var key3 = document.getElementById("txtRemove3");
//     var key4 = document.getElementById("txtRemove4");
//     var key5 = document.getElementById("txtRemove5");
//     var key6 = document.getElementById("txtRemove6");
//     var key7 = document.getElementById("txtRemove7");
//     var key8 = document.getElementById("txtRemove8");
    
//     alert(key);
//     //localStorage.removeItem(key);

//     const temp = (key,key2, key3, key4, key5, key6, key7, key8);
//     for(let x = 0; x < temp.length; x++)
//     {if(temp[x].length > 1){
//         localStorage.removeItem(temp);
//     }

//     }
// }

btnImage.onclick = function(){
    var key = "headerImage:";
    var value = document.getElementById("PImage").files[0].name;
    // alert(value);
    if(key && value) 
    {
        localStorage.setItem(key,value);
        location.reload();
    }
}
btnHeadName.onclick = function(){
    var key = headerName.textContent;
    var value = textName.value;

    if(key && value.length > 0) 
    {
        localStorage.setItem(key,value);
        location.reload();
    }
    else{
        alert("Please input a value");
    }
    
}

btnHeadAddress.onclick = function(){
    var key = headerAddress.textContent;
    var value = textAddress.value;

    if(key && value.length > 0) 
    {
        localStorage.setItem(key,value);
        location.reload();
    }
    else{
        alert("Please input a value");
    }
    
}

btnHeadPhone.onclick = function(){
    var key = headerPhone.textContent;
    var value = textPhone.value;

    if(key && value.length > 0) 
    {
        localStorage.setItem(key,value);
        location.reload();
    }
    else{
        alert("Please input a value");
    }
    
}

btnHeadEmail.onclick = function(){
    var key = headerEmail.textContent;
    var value = textEmail.value;

    if(key && value.length > 0) 
    {
        localStorage.setItem(key,value);
        location.reload();
    }
    else{
        alert("Please input a value");
    }
}

btnJobName.onclick = function(){
    var key = headerJobName.textContent;
    var value = textJobName.value;

    if(key && value.length > 0) 
    {
        localStorage.setItem(key,value);
        location.reload();
    }
    else{
        alert("Please input a value");
    }
}

for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "headerName:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            textName.value = value;
        }
        else if(temp == "headerAddress:")
            {
                //console.log(temp);
                const value = localStorage.getItem(key);
    
                textAddress.value = value;
            }
        else if(temp == "headerNumber:")
            {
                //console.log(temp);
                const value = localStorage.getItem(key);
        
                textPhone.value = value;
            }
        else if(temp == "headerEmail:")
            {
                //console.log(temp);
                const value = localStorage.getItem(key);
    
                textEmail.value = value;
            }
        else if(temp == "headerJobName:")
            {
                //console.log(temp);
                const value = localStorage.getItem(key);
    
                textJobName.value = value;
            }
        else if (temp == "headerImage:"){
                //console.log(temp);
                const value = localStorage.getItem(key);
                var temp = document.getElementById("PImage"); 
                temp.value = value;
        }
    }
//#endregion

//#region SECTION 1 Main Title
const btnSection1Title = document.getElementById("btnSaveSection1Title");
const Section1TitleKey = document.getElementById("labelSection1");
const Section1TitleValue = document.getElementById("textSection1");
const PbtnSave1 = document.getElementById("btnSaveParagraph");


btnSection1Title.onclick = function(){
    var key = Section1TitleKey.textContent;
    var value =  Section1TitleValue.value;
    if(key.length > 0  && value.length > 0) 
    {
        localStorage.setItem("A"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "ASectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section1TitleValue.value = value;
        }
    }

//#endregion

//#region Section 1
const outputSection1 = document.getElementById("Section1Output");
PbtnSave1.onclick = function(){
    var pKey = "ASectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph1Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph1Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0 )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave1 = document.getElementById("btnSaveList");
LbtnSave1.onclick = function(){
    var pKey = "ASectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave1 = document.getElementById("btnSaveER");
ERbtnSave1.onclick = function(){
    var pKey = "ASectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate1").value;

    const PValueSectionToDate1 = document.getElementById("ERDate2").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate1");
    const PValueSectionRDDate = document.getElementById("rdDate2");

    const PValueOC = document.getElementById("ERSectionOC").value;
    const PValueCS = document.getElementById("ERSectionCS").value;
    const PValueList = document.getElementById("ERSectionL").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}




for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "ASectionValue:"){
        var pOrder = JSON.parse(localStorage.getItem(tNum)); 
        outputSection1.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        for(o in pOrder)
        {
            var a = o.substring(0,1);
  
           
            if(a == 'P'){
                // outputSection1.innerHTML += '<td>' + o + " : " + '</td>' + '<td>'  + pOrder[o] + '</td>';
                outputSection1.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection1.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection1.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
        
    }
    
}
//#endregion

//#region SECTION 2 Main Title

const btnSection2Title = document.getElementById("btnSaveSection2Title");
const Section2TitleValue = document.getElementById("textSection2");
btnSection2Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection2");
    var key = Section2TitleKey.textContent;
    var value =  Section2TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("B"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "BSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section2TitleValue.value = value;
        }
    }

//#endregion
//#region Section 2

const PbtnSave2 = document.getElementById("btnSaveParagraph2");
PbtnSave2.onclick = function(){
    var pKey = "BSectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph2Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph2Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave2 = document.getElementById("btnSaveList2");
LbtnSave2.onclick = function(){
    var pKey = "BSectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey2").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue2").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave2 = document.getElementById("btnSaveER2");
ERbtnSave2.onclick = function(){
    var pKey = "BSectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection2").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate21").value;

    const PValueSectionToDate1 = document.getElementById("ERDate22").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent2").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate21");
    const PValueSectionRDDate = document.getElementById("rdDate22");

    const PValueOC = document.getElementById("ERSectionOC2").value;
    const PValueCS = document.getElementById("ERSectionCS2").value;
    const PValueList = document.getElementById("ERSectionL2").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection2 = document.getElementById("Section1Output2");
for(let x = 0; x < localStorage.length; x++)
{   
    const tNum = localStorage.key(x);
    if(tNum == "BSectionValue:"){
        outputSection2.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection2.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection2.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection2.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion

//#region SECTION 3 Main Title
const btnSection3Title = document.getElementById("btnSaveSection3Title");
const Section3TitleValue = document.getElementById("textSection3");
btnSection3Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection3");
    var key = Section2TitleKey.textContent;
    var value =  Section3TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("C"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "CSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section3TitleValue.value = value;
        }
    }

//#endregion
//#region Section 3

const PbtnSave3 = document.getElementById("btnSaveParagraph3");
PbtnSave3.onclick = function(){
    var pKey = "CSectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph3Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph3Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave3 = document.getElementById("btnSaveList3");
LbtnSave3.onclick = function(){
    var pKey = "CSectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey3").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue3").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave3 = document.getElementById("btnSaveER3");
ERbtnSave3.onclick = function(){
    var pKey = "CSectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection3").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate31").value;

    const PValueSectionToDate1 = document.getElementById("ERDate32").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent3").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate31");
    const PValueSectionRDDate = document.getElementById("rdDate32");

    const PValueOC = document.getElementById("ERSectionOC3").value;
    const PValueCS = document.getElementById("ERSectionCS3").value;
    const PValueList = document.getElementById("ERSectionL3").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection3 = document.getElementById("Section1Output3");
for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "CSectionValue:"){
        outputSection3.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection3.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection3.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection3.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion

//#region SECTION 4 Main Title
const btnSection4Title = document.getElementById("btnSaveSection4Title");
const Section4TitleValue = document.getElementById("textSection4");
btnSection4Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection4");
    var key = Section2TitleKey.textContent;
    var value =  Section4TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("D"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "DSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section4TitleValue.value = value;
        }
    }

//#endregion
//#region Section 4

const PbtnSave4 = document.getElementById("btnSaveParagraph4");
PbtnSave4.onclick = function(){
    var pKey = "DSectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph4Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph4Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave4 = document.getElementById("btnSaveList4");
LbtnSave4.onclick = function(){
    var pKey = "DSectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey4").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue4").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave4 = document.getElementById("btnSaveER4");
ERbtnSave4.onclick = function(){
    var pKey = "DSectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection4").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate41").value;

    const PValueSectionToDate1 = document.getElementById("ERDate42").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent4").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate41");
    const PValueSectionRDDate = document.getElementById("rdDate42");

    const PValueOC = document.getElementById("ERSectionOC4").value;
    const PValueCS = document.getElementById("ERSectionCS4").value;
    const PValueList = document.getElementById("ERSectionL4").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection4 = document.getElementById("Section1Output4");
for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "DSectionValue:"){
        outputSection4.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection4.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection4.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection4.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion

//#region SECTION 5 Main Title
const btnSection5Title = document.getElementById("btnSaveSection5Title");
const Section5TitleValue = document.getElementById("textSection5");
btnSection5Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection5");
    var key = Section2TitleKey.textContent;
    var value =  Section5TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("E"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "ESectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section5TitleValue.value = value;
        }
    }

//#endregion
//#region Section 5

const PbtnSave5 = document.getElementById("btnSaveParagraph5");
PbtnSave5.onclick = function(){
    var pKey = "ESectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph5Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph5Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave5 = document.getElementById("btnSaveList5");
LbtnSave5.onclick = function(){
    var pKey = "ESectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey5").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue5").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave5 = document.getElementById("btnSaveER5");
ERbtnSave5.onclick = function(){
    var pKey = "ESectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection5").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate51").value;

    const PValueSectionToDate1 = document.getElementById("ERDate52").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent5").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate51");
    const PValueSectionRDDate = document.getElementById("rdDate52");

    const PValueOC = document.getElementById("ERSectionOC5").value;
    const PValueCS = document.getElementById("ERSectionCS5").value;
    const PValueList = document.getElementById("ERSectionL5").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection5 = document.getElementById("Section1Output5");
for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "ESectionValue:"){
        outputSection5.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection5.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection5.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection5.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion

//#region SECTION 6 Main Title
const btnSection6Title = document.getElementById("btnSaveSection6Title");
const Section6TitleValue = document.getElementById("textSection6");
btnSection6Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection6");
    var key = Section2TitleKey.textContent;
    var value =  Section6TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("F"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "FSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section6TitleValue.value = value;
        }
    }

//#endregion
//#region Section 6
const PbtnSave6 = document.getElementById("btnSaveParagraph6");
PbtnSave6.onclick = function(){
    var pKey = "FSectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph6Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph6Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave6 = document.getElementById("btnSaveList6");
LbtnSave6.onclick = function(){
    var pKey = "FSectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey6").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue6").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave6 = document.getElementById("btnSaveER6");
ERbtnSave6.onclick = function(){
    var pKey = "FSectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection6").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate61").value;

    const PValueSectionToDate1 = document.getElementById("ERDate62").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent6").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate61");
    const PValueSectionRDDate = document.getElementById("rdDate62");

    const PValueOC = document.getElementById("ERSectionOC6").value;
    const PValueCS = document.getElementById("ERSectionCS6").value;
    const PValueList = document.getElementById("ERSectionL6").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection6 = document.getElementById("Section1Output6");
for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "FSectionValue:"){
        outputSection6.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection6.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection6.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection6.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion

//#region SECTION 7 Main Title
const btnSection7Title = document.getElementById("btnSaveSection7Title");
const Section7TitleValue = document.getElementById("textSection7");
btnSection7Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection7");
    var key = Section2TitleKey.textContent;
    var value =  Section7TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("G"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "GSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section7TitleValue.value = value;
        }
    }

//#endregion
//#region Section 7

const PbtnSave7 = document.getElementById("btnSaveParagraph7");
PbtnSave7.onclick = function(){
    var pKey = "GSectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph7Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph7Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave7 = document.getElementById("btnSaveList7");
LbtnSave7.onclick = function(){
    var pKey = "GSectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey7").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue7").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave7 = document.getElementById("btnSaveER7");
ERbtnSave7.onclick = function(){
    var pKey = "GSectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection7").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate71").value;

    const PValueSectionToDate1 = document.getElementById("ERDate72").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent7").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate71");
    const PValueSectionRDDate = document.getElementById("rdDate72");

    const PValueOC = document.getElementById("ERSectionOC7").value;
    const PValueCS = document.getElementById("ERSectionCS7").value;
    const PValueList = document.getElementById("ERSectionL7").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection7 = document.getElementById("Section1Output7");
for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "GSectionValue:"){
        outputSection7.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection7.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection7.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection7.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion

//#region SECTION 8 Main Title
const btnSection8Title = document.getElementById("btnSaveSection8Title");
const Section8TitleValue = document.getElementById("textSection8");
btnSection8Title.onclick = function(){
    const Section2TitleKey = document.getElementById("labelSection8");
    var key = Section2TitleKey.textContent;
    var value =  Section8TitleValue.value;
    if(key && value) 
    {
        localStorage.setItem("H"+ key ,value);
        location.reload();
    }
}
for(let x = 0; x < localStorage.length; x++)
    {
        const key = localStorage.key(x);
        var temp = key;
        if(temp == "HSectionMainTitle:")
        {
            //console.log(temp);
            const value = localStorage.getItem(key);
            Section8TitleValue.value = value;
        }
    }

//#endregion
//#region Section 8

const PbtnSave8 = document.getElementById("btnSaveParagraph8");
PbtnSave8.onclick = function(){
    var pKey = "HSectionValue:";
    const PKeySection1_Value = document.getElementById("txtParagraph8Key").value;
    const PKeySection1 = "P" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtParagraph8Value").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}


const LbtnSave8 = document.getElementById("btnSaveList8");
LbtnSave8.onclick = function(){
    var pKey = "HSectionValue:";
    const PKeySection1_Value = document.getElementById("txtListKey8").value;
    const PKeySection1 = "L" + PKeySection1_Value;
    const PValueSection1 = document.getElementById("txtListValue8").value;
    var obj = {};

    if(pKey && PKeySection1.length > 0 && PValueSection1.length > 0)
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSection1;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSection1;
                }
                else
                {
                    obj[PKeySection1] = PValueSection1;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const ERbtnSave8 = document.getElementById("btnSaveER8");
ERbtnSave8.onclick = function(){
    var pKey = "HSectionValue:";
    const PKeySection1_Value = document.getElementById("ERSection8").value;
    const PKeySection1 = "E" + PKeySection1_Value;

    const PValueSectionFromDate1 = document.getElementById("ERDate81").value;

    const PValueSectionToDate1 = document.getElementById("ERDate82").value;
    const PValueSectionPresentDate1 = document.getElementById("ERPresent8").textContent;

    const PValueSectionRDPresent = document.getElementById("rdDate81");
    const PValueSectionRDDate = document.getElementById("rdDate82");

    const PValueOC = document.getElementById("ERSectionOC8").value;
    const PValueCS = document.getElementById("ERSectionCS8").value;
    const PValueList = document.getElementById("ERSectionL8").value;
    var obj = {};

    var toDate = "";


    if(PValueSectionRDPresent.checked == true){
        toDate = PValueSectionPresentDate1;
    }
    else if(PValueSectionRDDate.checked == true){
        toDate = PValueSectionToDate1;
    }

    if(pKey && PKeySection1.length > 0 && PValueSectionFromDate1 && PValueOC && PValueCS && PValueList && PValueSectionRDDate.checked == true || PValueSectionRDPresent.checked == true )
        {
            if(localStorage.getItem(pKey) === null) // this means that the table hasnt ordered yet
            {
                obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            else // this means that the order has ordered before and would like to add new orders
            {
                obj = JSON.parse(localStorage.getItem(pKey));
                if(obj.hasOwnProperty(PKeySection1)) // this means the item was already inserted before
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                else
                {
                    obj[PKeySection1] = PValueSectionFromDate1 + " - " + toDate + "\t" 
                    + PValueOC + "\t" + PValueCS + "\t" + PValueList;
                }
                localStorage.setItem(pKey, JSON.stringify(obj));
            }
            location.reload();
        }
}



const outputSection8 = document.getElementById("Section1Output8");
for(let x = 0; x < localStorage.length; x++)
{
    const tNum = localStorage.key(x);
    if(tNum == "HSectionValue:"){
        outputSection8.innerHTML = '<tr><th>KEY</th><th>VALUE</th></tr>';
        var pOrder = JSON.parse(localStorage.getItem(tNum));
        for(o in pOrder)
        {
            var a = o.substring(0,1);
            if(a == 'P'){
                outputSection8.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'L')
            {
                outputSection8.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
            else if(a == 'E'){
                outputSection8.innerHTML += '<tr><td>' + o + '</td>' + '<td>'  + pOrder[o] + '</td></tr>';
            }
        }
    }
    
}
//#endregion