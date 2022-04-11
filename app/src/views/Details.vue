<template>
  <fragment>
    <header-bar />
    <div
      class="hero-wrap hero-bread"
      style="background-image: url('/images/bg_1.jpg')"
    >
      <div class="container">
        <div
          class="row no-gutters slider-text align-items-center justify-content-center"
        ></div>
      </div>
    </div>
    <section class="ftco-section">
      <div class="container">
        <div class="row">
          <div class="col-lg-6 mb-5 ftco-animate">
            <img
              v-bind:src="product.image"
              class="img-fluid"
              alt="Colorlib Template"
            />
          </div>
          <div class="col-lg-6 product-details pl-md-5 ftco-animate">
            <h3>{{ product.name }}</h3>
            <div class="rating d-flex">
              <p class="text-left mr-4">
                <a href="#" class="mr-2">{{
                  product.rating ? product.rating.toFixed(1) : 0.0
                }}</a>
                <a href="#" v-for="a in product.rating" :key="a"
                  ><span class="ion-ios-star"></span
                ></a>
              </p>
            </div>
            <p class="price">
              <span
                >${{
                  product.price ? product.price.toFixed(2) : (0.0).toFixed(2)
                }}</span
              >
            </p>
            <p>{{ product.description }}</p>
            <div class="row mt-4">
              <div class="col-md-6">
                <div class="form-group d-flex">
                  <div class="select-wrap">
                    <div class="icon">
                      <span class="ion-ios-arrow-down"></span>
                    </div>
                    <select v-model="size" class="form-control">
                      <option value="Small">Small</option>
                      <option value="Medium">Medium</option>
                      <option value="Large">Large</option>
                      <option value="Extra Large">Extra Large</option>
                    </select>
                  </div>
                </div>
              </div>
              <div class="w-100"></div>
              <div class="input-group col-md-6 d-flex mb-3">
                <span class="input-group-btn mr-2">
                  <button
                    type="button"
                    class="quantity-left-minus btn"
                    data-type="minus"
                    data-field=""
                    @click="minusQty()"
                  >
                    <i class="ion-ios-remove"></i>
                  </button>
                </span>
                <input
                  type="text"
                  id="quantity"
                  name="quantity"
                  class="form-control input-number"
                  min="1"
                  max="100"
                  v-model="qty"
                />
                <span class="input-group-btn ml-2">
                  <button
                    type="button"
                    class="quantity-right-plus btn"
                    data-type="plus"
                    data-field=""
                    @click="plusQty()"
                  >
                    <i class="ion-ios-add"></i>
                  </button>
                </span>
              </div>
              <div class="w-100"></div>
              <br />
            </div>
            <p class="btn btn-black py-3 px-5" @click="AddProduct()">
              Add to Cart
            </p>
          </div>
        </div>
      </div>
    </section>
  </fragment>
</template>

<script>
import axios from "axios";
import BreadCrumb from "../components/BreadCrumb.vue";
import HeaderBar from "../components/HeaderBar.vue";
import json from "../data/data.json";
import { useToast } from "vue-toastification";

var currentProduct = null;

export default {
  name: "Details",
  components: { BreadCrumb, HeaderBar },
  setup() {
    // Get toast interface
    const toast = useToast();
    return { toast };
  },
  data() {
    return {
      currentPage: this.$route.params.id,
      product: {},
      size: "Small",
      qty: 1,
      isAddToCartDisabled: true,
      isLoggedIn: false,
      reviews: [],
    };
  },
  methods: {
    minusQty() {
      if (this.qty > 0) this.qty -= 1;

      this.udapteAddToCartBtn();
    },
    plusQty() {
      this.qty += 1;
      this.udapteAddToCartBtn();
    },
    AddProduct() {
      var cart = localStorage.getItem("cart");
      var currProduct = {
        id: this.$route.params.id,
        size: this.size,
        qty: this.qty,
        image: this.product.image,
        name: this.product.name,
        price: this.product.price,
        total: this.product.price * this.qty,
      };

      if (cart) {
        cart = JSON.parse(cart);

        cart = [
          ...cart.filter((x) => {
            return x.id != currProduct.id;
          }),
          currProduct,
        ];
      } else {
        cart = [currProduct];
      }

      localStorage.setItem("cart", JSON.stringify(cart));
      var orderId = localStorage.getItem("orderId");

      if (!orderId) {
        orderId = Math.floor(Math.random() * 10 + 1);
        localStorage.setItem("orderId", orderId);
      }

      axios
        .post("http://localhost:56990/api/Carts", {
          id: 0,
          orderId: orderId,
          productId: currProduct.id,
          qty: currProduct.qty,
          price: currProduct.price,
          tax: 0,
          total: currProduct.total,
        })
        .then((response) => {
          this.$root.$refs.HeaderBar.updateCartCount();
        })
        .catch(function (error) {
          // this.isInvalidLogin = true;
        });
    },
    udapteAddToCartBtn() {
      this.isAddToCartDisabled = this.qty > 0 && this.size ? false : true;
    },
    loadProduct(id) {
      let productDetailsURL = "http://localhost:56990/api/Products/" + id;
      let reviewsURL = "http://localhost:3655/api/Review/" + id;

      const fetchURL = (url) => axios.get(url);

      const promiseArray = [productDetailsURL].map(fetchURL);

      Promise.all(promiseArray)
        .then((data) => {
          if (data[0] && data[0].data) {
            this.product = data[0].data;
            //this.currentPage = this.product.name;
          }

          console.log(this.product);

          // if (data[1] && data[1].data) {
          //   this.reviews = data[1].data;
          //   console.log(this.reviews);
          // }
        })
        .catch((err) => {
          console.log(err);
        });

      // axios
      //   .get("http://localhost:3000/api/product?id=" + id)
      //   .then((response) => {
      //     if (response && response.status == 200) {
      //       if (response.data) {
      //         this.product = response.data;
      //         this.currentPage = this.product.name;
      //         // this.product.reviews = Object.assign(
      //         //   [],
      //         //   response.data.data[0].reviews
      //         // );

      //         this.reviews = response.data.data[0].reviews
      //           ? response.data.data[0].reviews
      //           : [];
      //       }
      //     }
      //   });
    },
  },
  created() {
    var products = JSON.parse(localStorage.getItem("products"));

    // if (products && products.length > 0) {
    //   var tempProduct = products.filter((x) => x.id == this.product.id)[0]
    //     .reviews;
    //   this.reviews = tempProduct;
    // }

    var user = JSON.parse(localStorage.getItem("user"));
    if (user) {
      this.isLoggedIn = true;
    } else {
      this.isLoggedIn = false;
    }

    this.$root.$refs.HeaderBar.updateCartCount();
  },
  mounted() {
    this.loadProduct(this.$route.params.id);

    this.$root.$refs.HeaderBar.updateCartCount();
  },
};
</script>
