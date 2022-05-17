const SerialPort = require("serialport");
const Readline = require("@serialport/parser-readline");

const port = new SerialPort("COM1", {
    baudRate: 9600,
});
const parser = new Readline();
port.pipe(parser);

port.on("open", function() {
    console.log("-- Connection opened --");
    parser.on("data", function(data) {
        console.log("Serial Data received: " + data);
        setTemperature(Number(data));
        addTemperature(Number(data));
    });
});

function setTemperature(temperature){
    const http = require('http');
    
    const options = {
        host: 'localhost',
        port: 3000,
        secure: false,
        path: '/estoques/0',
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=UTF-8'
        }
    };
    const request = http.request(options, (res) => {
        if (res.statusCode !== 200) {
            console.error(`Did not get a Created from the server. Code: ${res.statusCode}`);
            res.resume();
            return;
        }
        let data = '';
        res.on('data', (chunk) => {
            data += chunk;
        });
        res.on('close', () => {
            console.log('Temperatura do estoque atualizada.');
            console.log(JSON.parse(data));
        });
    });
    
    //let ts = Math.floor(Date.now()/1000);
    const requestData = {
        "temperatura": temperature,
        "capacidade": 50000
    };
       
    request.write(JSON.stringify(requestData));
    request.end();
    request.on('error', (err) => {
        console.error(`Encountered an error trying to make a request: ${err.message}`);
    });
}

function addTemperature(temperature){
    const http = require('http');
    
    const options = {
        host: 'localhost',
        port: 3000,
        secure: false,
        path: '/temperaturas',
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=UTF-8'
        }
    };
    const request = http.request(options, (res) => {
        if (res.statusCode !== 201) {
            console.error(`Did not get a Created from the server. Code: ${res.statusCode}`);
            res.resume();
            return;
        }
        let data = '';
        res.on('data', (chunk) => {
            data += chunk;
        });
        res.on('close', () => {
            console.log('Nova leitura adicionada no histórico.');
            console.log(JSON.parse(data));
        });
    });
    
    let ts = Math.floor(Date.now()/1000);
    const requestData = {
        "temperatura": temperature,
        "timestamp": ts,
        "estoque": "0"
    };
       
    request.write(JSON.stringify(requestData));
    request.end();
    request.on('error', (err) => {
        console.error(`Encountered an error trying to make a request: ${err.message}`);
    });
}

async function requestTemp(){
    const delay = require('delay');
    port.write("[TT]");
    await delay(250);
}

setInterval(requestTemp,30000);
