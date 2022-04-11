<template>
  <fragment>
    <header-bar />

    <section id="home-section" class="hero">
      <div class="home-slider owl-carousel" style="display: block">
        <div
          class="slider-item"
          style="background-image: url(/images/bg_2.jpg)"
        >
          <div class="overlay"></div>
          <div class="container">
            <div
              class="row slider-text justify-content-center align-items-center"
              data-scrollax-parent="true"
            >
              <div class="col-md-12 ftco-animate text-center">
                <h1 class="mb-2">We serve Fresh Vegestables &amp; Fruits</h1>
                <h2 class="subheading mb-4">
                  We deliver organic vegetables &amp; fruits
                </h2>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <section
      class="ftco-section ftco-category ftco-no-pt"
      style="margin-top: 6%"
    >
      <div class="container">
        <div class="row">
          <div class="col-md-8">
            <div class="row">
              <div class="col-md-6 order-md-last align-items-stretch d-flex">
                <div
                  class="category-wrap-2 ftco-animate img align-self-stretch d-flex"
                  style="background-image: url(/images/category.jpg)"
                >
                  <div class="text text-center">
                    <h2>Organic</h2>
                    <p>Protect the health of every home</p>
                    <p><a href="/shop" class="btn btn-primary">Shop now</a></p>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div
                  class="category-wrap ftco-animate img mb-4 d-flex align-items-end"
                  style="
                    background-image: url(/images/category-1.jpg);
                    cursor: pointer;
                  "
                  @click="goToShop('Fruits')"
                >
                  <div class="text px-3 py-1">
                    <h2 class="mb-0"><a href="#">Fruits</a></h2>
                  </div>
                </div>
                <div
                  class="category-wrap ftco-animate img d-flex align-items-end"
                  style="background-image: url(/images/category-2.jpg)
                    cursor: pointer;"
                  @click="goToShop('Vegitable')"
                >
                  <div class="text px-3 py-1">
                    <h2 class="mb-0"><a href="#">Vegetables</a></h2>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="col-md-4">
            <div
              class="category-wrap ftco-animate img mb-4 d-flex align-items-end"
              style="background-image: url(/images/category-3.jpg)
                    cursor: pointer;"
              @click="goToShop('Juices')"
            >
              <div class="text px-3 py-1">
                <h2 class="mb-0"><a href="#">Juices</a></h2>
              </div>
            </div>
            <div
              class="category-wrap ftco-animate img d-flex align-items-end"
              style="background-image: url(/images/category-4.jpg)
                    cursor: pointer;"
              @click="goToShop('Dried')"
            >
              <div class="text px-3 py-1">
                <h2 class="mb-0"><a href="#">Dried</a></h2>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </fragment>
</template>

<script>
import HeaderBar from "../components/HeaderBar.vue";
import axios from "axios";

export default {
  name: "Home",
  components: {
    HeaderBar,
  },
  data() {
    return {};
  },
  methods: {
    goToShop(category) {
      localStorage.setItem("category", category);
      this.$router.push("Shop");
      location.reload();
    },
  },
  created() {
    axios
      .get("http://localhost:56990/api/Products")
      .then((response) => {
        if (!localStorage.getItem("products")) {
          localStorage.setItem("products", JSON.stringify(response.data));
        }
      })
      .catch(function (error) {
        this.isInvalidLogin = true;
      });
  },
};
</script>
