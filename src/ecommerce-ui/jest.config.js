/*module.exports = {
  preset: "@vue/cli-plugin-unit-jest"
};*/

// eslint-disable-next-line no-undef
module.exports = {
  verbose: true,
  moduleFileExtensions: ["js", "vue"],
  moduleNameMapper: {
    "^.+\\.module\\.(css|sass|scss)$": "identity-obj-proxy",
    "\\.(css|less)$": "identity-obj-proxy",
    "@/(.*)$": "<rootDir>/src/$1",
    "^vue$": "vue/dist/vue.common.js"
  },
  transform: {
    "^.+\\.vue$": "vue-jest",
    "^.+\\.jsx?$": "babel-jest"
  },
  transformIgnorePatterns: [],
  testMatch: [
    "**/tests/unit/**/*.spec.(js|jsx|ts|tsx)|**/__tests__/*.(js|jsx|ts|tsx)"
  ],
  testURL: "http://localhost:4006/",
  setupFilesAfterEnv: ["./jest.setup.js"],
  collectCoverage: false,
  collectCoverageFrom: [
    "**/*.{js,vue}",
    "!**/node_modules/**",
    "!**/coverage/**",
    "!**/router/**",
    "!**/babel.config.js",
    "!**/jest.config.js",
    "!**/webpack.config.js",
    "!**/webpack.config.vendor.js",
    "!**/mock.js",
    "!**/*.mock.js",
    "!**/main.js",
    "!**/App.vue"
  ],
  coverageReporters: ["lcov", "text", "text-summary"]
};

