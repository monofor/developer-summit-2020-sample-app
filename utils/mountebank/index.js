const mb = require("mountebank");
const apiImposter = require("./imposters/api");

const mbServerInstance = mb.create({
    port: 4001,
    pidfile: "./mb.pid",
    logfile: "./mg.log",
    protofile: "./protofile.json",
    ipWhitelist: ["*"],
});

mbServerInstance.then(function () {
    apiImposter.addStubs();
});