<template>
  <fragment>
    <router-view />
  </fragment>
</template>

<script>
import Footer from "./components/Footer.vue";
import startup from "./components/Startup.vue";

export default {
  name: "App",
  components: { startup, Footer },
  data() {
    return {
      isLoggedIn: false,
    };
  },
  created() {},
};
</script>
