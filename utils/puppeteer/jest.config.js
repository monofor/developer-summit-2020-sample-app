module.exports = {
    preset: "jest-puppeteer",
    globals: {
        URL: "http://localhost:8080"
    },
    testMatch: ["**/__test__/**/*.test.js"],
    verbose: true,
    globalSetup: "./setup.js",
    globalTeardown: "./teardown.js",
    testEnvironment: "./puppeteer_environment.js"
};
