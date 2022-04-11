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
            <h1 class="mb-0 bread">Checkout</h1>
          </div>
        </div>
      </div>
    </div>

    <section class="ftco-section ftco-cart">
      <div class="container">
        <div class="row" v-if="cartItems && cartItems.length > 0">
          <div class="col-md-8 ftco-animate">
            <div class="cart-list">
              <table class="table">
                <thead class="thead-primary">
                  <tr class="text-center">
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>Product name</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Total</th>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    class="text-center"
                    v-for="item in cartItems"
                    :key="item.id"
                  >
                    <td class="product-remove">
                      <a href="#"
                        ><span
                          class="ion-ios-close"
                          @click="removeItem(item.id)"
                        ></span
                      ></a>
                    </td>

                    <td class="image-prod">
                      <div
                        class="img"
                        v-bind:style="{
                          backgroundImage: 'url(' + item.image + ')',
                        }"
                      ></div>
                    </td>

                    <td class="product-name">
                      <h3>{{ item.name }}</h3>
                    </td>

                    <td class="price">${{ item.price.toFixed(2) }}</td>

                    <td class="quantity">
                      <div class="input-group mb-3">
                        <input
                          type="text"
                          name="quantity"
                          class="quantity form-control input-number"
                          v-model="item.qty"
                          disabled="disabled"
                        />
                      </div>
                    </td>

                    <td class="total">${{ item.total.toFixed(2) }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div class="col-md-4 cart-wrap ftco-animate">
            <div class="cart-total mb-3">
              <h3>Cart Totals</h3>
              <p class="d-flex">
                <span>Subtotal</span>
                <span>${{ getSubTotal }}</span>
              </p>
              <p class="d-flex">
                <span>Tax</span>
                <span>${{ getTax }}</span>
              </p>
              <p class="d-flex">
                <span>Discount</span>
                <span>$0.00</span>
              </p>
              <hr />
              <p class="d-flex total-price">
                <span>Total</span>
                <span>${{ getTotal }}</span>
              </p>
            </div>
            <p>
              <a
                href="#"
                class="btn btn-primary py-3 px-4"
                @click="placeOrder()"
                >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Place Order
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a
              >
            </p>
          </div>
        </div>
        <div class="row text-center" v-else style="margin-left: 5%">
          <div class="col-md-12">
            <h4>Your shopping cart is empty!</h4>
          </div>
          <br />
          <br />
          <br />
          <div class="col-md-12">
            <p class="btn btn-black py-3 px-5" @click="redirectToShop()">
              Start Shopping
            </p>
          </div>
        </div>

        <div class="row justify-content-end"></div>
      </div>
    </section>
  </fragment>
</template>

<script>
import BreadCrumb from "../components/BreadCrumb.vue";
import HeaderBar from "../components/HeaderBar.vue";
import axios from "axios";

export default {
  name: "Cart",
  components: {
    BreadCrumb,
    HeaderBar,
  },
  data() {
    return {
      cartItems: [],
      orderId: 0,
    };
  },
  computed: {
    getSubTotal: function () {
      return this.cartItems
        .reduce((acc, curr) => {
          return acc + curr.price * curr.qty;
        }, 0.0)
        .toFixed(2);
    },
    getTax: function () {
      var subTotal2 = this.cartItems.reduce((acc, curr) => {
        return acc + curr.price * curr.qty;
      }, 0.0);

      return ((subTotal2 / 100) * 13).toFixed(2);
    },
    getTotal: function () {
      var subTotal1 = this.cartItems.reduce((acc, curr) => {
        return acc + curr.price * curr.qty;
      }, 0.0);
      return (subTotal1 + (subTotal1 / 100) * 13).toFixed(2);
    },
  },
  methods: {
    redirectToShop() {
      localStorage.removeItem("category");
      this.$router.push("Shop");
      location.reload();
    },
    getBackgroundImage(img) {
      return "background-image: url(" + img + ")";
    },
    minusQty(i) {
      if (this.cartItems[i].qty > 0) {
        this.cartItems[i].qty -= 1;
      }
    },
    plusQty(i) {
      this.cartItems[i].qty += 1;
    },
    removeItem(id) {
      this.cartItems = this.cartItems.filter((x) => {
        return x.id != id;
      });
      console.log(id, this.cartItems);
      localStorage.setItem("cart", JSON.stringify(this.cartItems));
    },
    placeOrder() {
      var subTot = this.cartItems.reduce((acc, curr) => {
        return acc + curr.price * curr.qty;
      }, 0.0);

      var orders = JSON.parse(localStorage.getItem("orders"));
      var currOrder = {
        orderNo: Math.floor(Math.random() * (1000000 - 10000 + 1)) + 10000,
        status: "Ordered",
        cart: this.cartItems,
        total: (subTot + (subTot / 100) * 13).toFixed(2),
        orderDate: new Date().toLocaleDateString("en-us", {
          weekday: "long",
          year: "numeric",
          month: "short",
          day: "numeric",
        }),
      };

      var orderId = localStorage.getItem("orderId");

      if (!orderId) {
        orderId = Math.floor(Math.random() * 10 + 1);
        localStorage.setItem("orderId", orderId);
      }

      axios
        .post("http://localhost:56990/api/Orders", {
          id: 0,
          customerId: 1,
          orderNo: orderId,
          isPlaced: true,
        })
        .then((response) => {
          localStorage.setItem("lastOrderNumber", orderId);

          localStorage.setItem("orderId", Math.floor(Math.random() * 10 + 1));
        })
        .catch(function (error) {
          //this.isInvalidLogin = true;
        });

      if (orders) {
        localStorage.setItem("orders", JSON.stringify([...orders, currOrder]));
      } else {
        localStorage.setItem("orders", JSON.stringify([currOrder]));
      }

      localStorage.setItem("lastOrderNumber", currOrder.orderNo);
      localStorage.removeItem("cart", []);

      this.$router.push("Success");
      location.reload();
    },
  },
  created() {
    var user = JSON.parse(localStorage.getItem("user"));
    if (user) {
      this.isLoggedIn = true;
      this.accountName = user.name;
    } else {
      this.isLoggedIn = false;
      this.accountName = "";
    }

    this.cartItems = JSON.parse(localStorage.getItem("cart"));
  },
};
</script>
