<template>
  <fragment>
    <header-bar />
    <div
      class="hero-wrap hero-bread"
      style="background-image: url('images/bg_1.jpg')"
    >
      <div class="container">
        <div
          class="row no-gutters slider-text align-items-center justify-content-center"
        >
          <div class="col-md-9 ftco-animate text-center">
            <h1 class="mb-0 bread">Products</h1>
          </div>
        </div>
      </div>
    </div>

    <section class="ftco-section">
      <div class="container">
        <div class="row justify-content-center">
          <div class="col-md-10 mb-5 text-center">
            <ul class="product-category">
              <li>
                <a
                  href="#"
                  v-bind:class="{ active: category == 'All' }"
                  @click="filterProduct('All')"
                  >All</a
                >
              </li>
              <li>
                <a
                  href="#"
                  v-bind:class="{ active: category == 'Vegetable' }"
                  @click="filterProduct('Vegetable')"
                  >Vegetables</a
                >
              </li>
              <li>
                <a
                  href="#"
                  v-bind:class="{ active: category == 'Fruits' }"
                  @click="filterProduct('Fruits')"
                  >Fruits</a
                >
              </li>
              <li>
                <a
                  href="#"
                  v-bind:class="{ active: category == 'Juice' }"
                  @click="filterProduct('Juice')"
                  >Juice</a
                >
              </li>
              <li>
                <a
                  href="#"
                  v-bind:class="{ active: category == 'Dried' }"
                  @click="filterProduct('Dried')"
                  >Dried</a
                >
              </li>
            </ul>
          </div>
        </div>
        <div class="row" v-if="products.length > 0">
          <div
            class="col-md-6 col-lg-3 ftco-animate"
            v-for="product in products"
            v-bind:key="product.id"
          >
            <div class="product">
              <a v-bind:href="redirect(product.id)" class="img-prod"
                ><img
                  class="img-fluid"
                  v-bind:src="product.image"
                  alt="Colorlib Template"
                />
                <div class="overlay"></div>
              </a>
              <div class="text py-3 pb-4 px-3 text-center">
                <h3>
                  <a href="#">{{ product.name }}</a>
                </h3>
                <div class="d-flex">
                  <div class="pricing" style="display: block">
                    <p class="price">
                      <span class="price-sale"
                        >${{ product.price.toFixed(2) }}</span
                      >
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row" v-else>
          <h5 style="margin-left: 43%">Products not available!</h5>
        </div>
      </div>
    </section>
  </fragment>
</template>

<script>
import BreadCrumb from "../components/BreadCrumb.vue";
import FilterMenu from "../components/FilterMenu.vue";
import HeaderBar from "../components/HeaderBar.vue";
import json from "./../data/data.json";

export default {
  name: "Shop",
  components: {
    BreadCrumb,
    FilterMenu,
    HeaderBar,
  },
  data() {
    return {
      isLoggedIn: false,
      products: [],
      category: null,
    };
  },
  methods: {
    filterProduct(pCategory) {
      if (localStorage.getItem("products")) {
        var p = localStorage.getItem("products");

        if (p) {
          var prds = JSON.parse(p);

          if (pCategory == "All") {
            this.products = prds;
          } else {
            this.products = prds.filter((x) => x.category == pCategory);
          }
        } else {
          this.products = [];
        }

        this.category = pCategory;
      }
    },
    redirect(id) {
      return "/shop/" + id;
    },
  },
  created() {
    if (localStorage.getItem("products")) {
      var tempProducts = localStorage.getItem("products");

      if (tempProducts) {
        var selectedCategory = localStorage.getItem("category");
        var prods = JSON.parse(tempProducts);

        if (selectedCategory) {
          this.category = selectedCategory;
          this.products = prods.filter((x) => x.category == selectedCategory);
        } else {
          this.category = "All";
          this.products = prods;
        }
      }
    }
  },
  mounted() {},
};
</script>
