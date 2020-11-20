import axios from "axios";

beforeAll(() => {
    let hostUrl = "https://localhost:5001";
    const apiHostUrl = process.env.API_HOST_URL; // eslint-disable-line no-undef

    if (apiHostUrl !== undefined) {
        hostUrl = apiHostUrl;
    }

    axios.defaults.baseURL = hostUrl;
});
