const mbhelper = require("../mbhelper");
const productStubs = require("../stubs/product");

function addStubs() {
    const stubs = [...productStubs];

    const imposter = {
        port: 4006,
        protocol: "http",
        stubs: stubs,
    };

    return mbhelper.postImposter(imposter);
}

module.exports = {addStubs};