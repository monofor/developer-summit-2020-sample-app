const fetch = require("node-fetch");

function postImposter(body) {
    const url = "http://127.0.0.1:4001/imposters";

    return fetch(url, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(body),
    });
}

module.exports = {postImposter};