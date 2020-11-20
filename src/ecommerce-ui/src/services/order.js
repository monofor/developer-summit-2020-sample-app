import axios from "axios";

export default {
    get(){
        return axios.get("orders");
    },
    post(data){
        return axios.post("orders", data);
    }
}