import axios from "axios";

beforeEach(() => {
    const apiHostUrl = process.env.API_HOST_URL; // eslint-disable-line no-undef

    if (apiHostUrl !== undefined) {
        axios.defaults.baseURL = apiHostUrl;
    }
});
