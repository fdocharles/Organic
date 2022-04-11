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
        <div class="row">
          <div class="col-md-6 offset-md-3 text-center">
            <h1 class="success-order-no-title" sty>
              Order Placed Successfully !
            </h1>
            <h5 style="margin-top: 30px">Your Order No : {{ orderNo }}</h5>
          </div>
        </div>
      </div>
    </section>
  </fragment>
</template>

<script>
import HeaderBar from "../components/HeaderBar.vue";

export default {
  components: { HeaderBar },
  name: "Success",
  data() {
    return {
      orderNo: 0,
    };
  },
  created() {
    this.cartItems = JSON.parse(localStorage.getItem("cart"));
    this.orderNo = localStorage.getItem("lastOrderNumber");
  },
};
</script>
