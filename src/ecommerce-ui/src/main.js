import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import axios from "axios";
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

Vue.config.productionTip = false;
axios.defaults.baseURL = process.env.API_HOST_URL || "https://localhost:5001";

Vue.prototype.$http = axios;

new Vue({
    router,
    render: h => h(App)
}).$mount("#app");
