<template>
  <div id="app">
    <!-- <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </div> -->
    <Navbar />

    <div class="main">
      <router-view />
    </div>

    <Footer />
  </div>
</template>

<script>
import Navbar from "./components/Navbar.vue";
import Footer from "./components/Footer.vue";
export default {
  name: "App",
  components: {
    Navbar,
    Footer,
  },
};
</script>>

<style lang="scss">
@import "../styles/main.scss";

* {
  font-family: "Poppins", sans-serif;
  margin: 0;
  padding: 0;
}
.main {
  margin-top: $nav-height;
  min-height: calc(100vh - #{$nav_height} - #{$footer-height} - #{$nav-height});
  background-color: $background-color;
  margin-bottom: $nav-height;
  width: 100%;
}
body {
  padding: 0;
  margin: 0;

  // background: black;
  // filter: invert(1) hue-rotate(180deg);
  
  // img, .map {
  //   filter: invert(1) hue-rotate(180deg);
  // }
}

#app {
  display: flex;
  align-items: center;
  flex-flow: column;
}
.view {
  padding-top: 72px;
}
</style>
