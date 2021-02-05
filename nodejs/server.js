var websocket = require("ws");
var callbackInitServer = ()=>{
    console.log("Sever is running.");
}
var wss = new websocket.Server({port:4243}, callbackInitServer);
var wsList = [];
wss.on("connection", (ws)=>{
    console.log("Client connected.");
    
    wsList.push(ws);
    
    ws.on("message",(data)=>{
        console.log("Send from Client :"+data);
        BroadCast(data);
    });
    
    ws.on("close", ()=>{
        console.log("Disconnected.");
        wsList = ArrayRemove(wsList, ws);
    });
});

function ArrayRemove(arr, value){
    return arr.filter((element)=>{
        return element != value;
    });
}

function BroadCast(data){
    for(var i = 0;i < wsList.length; i++){
        wsList[i].send(data);
    }
}