import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import Fragment from "vue-fragment";
import axios from "axios";
import VueAxios from "vue-axios";

import Toast from "vue-toastification";

import "vue-toastification/dist/index.css";

Vue.use(Fragment.Plugin);
Vue.use(VueAxios, axios);

Vue.config.productionTip = false;
const options = {
  // You can set your default options here
};

Vue.use(Toast, options);

let app = new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");

global.vm = app;
