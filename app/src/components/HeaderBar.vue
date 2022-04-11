<template>
  <fragment>
    <div class="py-1 bg-primary">
      <div class="container">
        <div
          class="row no-gutters d-flex align-items-start align-items-center px-md-0"
        >
          <div class="col-lg-12 d-block">
            <div class="row d-flex">
              <div class="col-md pr-4 d-flex topper align-items-center">
                <div
                  class="icon mr-2 d-flex justify-content-center align-items-center"
                >
                  <span class="icon-phone2"></span>
                </div>
                <span class="text">+1 226 505 9123</span>
              </div>
              <div class="col-md pr-4 d-flex topper align-items-center">
                <div
                  class="icon mr-2 d-flex justify-content-center align-items-center"
                >
                  <span class="icon-paper-plane"></span>
                </div>
                <span class="text">organic@gmail.com</span>
              </div>
              <div
                class="col-md-5 pr-4 d-flex topper align-items-center text-lg-right"
              >
                <span class="text"
                  >3-5 Business days delivery &amp; Free Returns</span
                >
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <nav
      class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-dark ftco-navbar-light"
      id="ftco-navbar"
    >
      <div class="container">
        <a class="navbar-brand" href="#">Organic</a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#ftco-nav"
          aria-controls="ftco-nav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="oi oi-menu"></span> Menu
        </button>

        <div class="collapse navbar-collapse" id="ftco-nav">
          <ul class="navbar-nav ml-auto">
            <li class="nav-item active">
              <a href="/" class="nav-link">Home</a>
            </li>
            <li class="nav-item active">
              <a href="/shop" class="nav-link">Shop</a>
            </li>
            <li class="nav-item cta cta-colored">
              <a href="/checkout" class="nav-link"
                ><span class="icon-shopping_cart"></span>[{{ cartCount }}]</a
              >
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </fragment>
</template>

<script>
// import MenuBar from "./MenuBar.vue";
// import Login from "./Login.vue";
// import HeaderBarControls from "./HeaderBarControls.vue";
// import ToastMessage from "./ToastMessage.vue";

import carousel from "vue-owl-carousel";

export default {
  name: "HeaderBar",
  components: {
    carousel,
    // MenuBar,
    // Login,
    // HeaderBarControls,
    // ToastMessage,
  },
  data() {
    return {
      cartCount: 0,
      // accountName: "",
    };
  },
  computed: {
    getCartCount: () => {
      var length = JSON.parse(localStorage.getItem("cart")).length;
      return length > 0 ? length : 0;
    },
  },

  methods: {
    updateCartCount() {
      var length = JSON.parse(localStorage.getItem("cart")).length;
      this.cartCount = length > 0 ? length : 0;
    },
    redirectToShop() {
      localStorage.removeItem("category");
      this.$router.push("Shop");
      location.reload();
    },
  },
  created() {
    this.$root.$refs.HeaderBar = this;
    // var user = JSON.parse(localStorage.getItem("user"));
    // if (user) {
    //   this.isLoggedIn = true;
    //   this.accountName = user.name;
    // } else {
    //   this.isLoggedIn = false;
    //   this.accountName = "";
    // }
  },
};
</script>
