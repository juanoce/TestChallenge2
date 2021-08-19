 

function fillroom(obj)
{   
    const myArr = obj.split("|");
    $("#tbid").val(myArr[0].replace('"', ''));
    $("#tbname").val(myArr[1]);
    $("#tbnumber").val(myArr[2]);
    $("#tboccupant").val(myArr[3].replace('"',''));
}

function deleteRoom() {
    var ed = $('#ddl1').val();

    if (ed == "0") return;

    if (confirm("Delete Room " + ed + " ?")) {
        var id = ed;
        var name = "DELETE";
        var number = "";
        var occupant = "";

        var myData = {};
        myData.Id = id;
        myData.Name = name;
        myData.Number = number;
        myData.Occupant = occupant;
        var env = JSON.stringify(myData);

        var req = new XMLHttpRequest();        
        req.open('POST', 'http://www.micajota.es/api/values/', true);
        req.setRequestHeader('Content-Type', 'application/json');       
        req.onreadystatechange = function (aEvt) {
            if (req.readyState == 4) {
                if (req.status == 200) {
                    alert(req.responseText);
                }
            }
        };
        req.send(env);
    }
    
}
function CreateRoom() {
    var id = "0";
    var name = $('#tbname').val();
    var number = $('#tbnumber').val();
    var occupant = $('#tboccupant').val();

    var myData = {};
    myData.Id = id;
    myData.Name = name;
    myData.Number = number;
    myData.Occupant = occupant;
    var env = JSON.stringify(myData);

    var req = new XMLHttpRequest();
    
    req.open('POST', 'http://www.micajota.es/api/values/', true);    
    req.setRequestHeader('Content-Type', 'application/json');  
    req.onreadystatechange = function (aEvt) {
        if (req.readyState == 4) {
            if (req.status == 200) {
                alert(req.responseText);
                eraseData();
            }
        }
    };
    req.send(env);
}
function eraseData() {
    $('#tbname').val("");
    $('#tbnumber').val("");
    $('#tboccupant').val("");

}
   function getAlldata() {
       var ed = $('#ddl1').val();
       var req = new XMLHttpRequest();
        
       req.open('GET', 'http://www.micajota.es/api/values/' + ed, true);     
       
        req.onreadystatechange = function (aEvt) {
            if (req.readyState == 4) {
                if (req.status == 200) {
                    fillroom(req.responseText);
                }
                else
                    alert("Error loading page\n");
            }
        };
        req.send(null);
    }
    function updateRoom() {
        var id = $('#tbid').val();
        var name = $('#tbname').val();
        var number = $('#tbnumber').val();
        var occupant = $('#tboccupant').val();      
        
        var myData = {};
        myData.Id = id;
        myData.Name = name;
        myData.Number = number;
        myData.Occupant = occupant;
        var env = JSON.stringify(myData);

        var req = new XMLHttpRequest();    
        /*req.setRequestHeader('Access-Control-Allow-Origin', '*')*/;
        req.open('POST', 'http://www.micajota.es/api/values/', true);
        req.setRequestHeader('Content-Type', 'application/json');  
        req.onreadystatechange = function (aEvt) {
            if (req.readyState == 4) {
                if (req.status == 200) {
                    alert(req.responseText);                  
                }                 
            }
        };
        req.send(env);
       
    }