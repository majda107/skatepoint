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
  max-width: 1200px;
  padding: 0 20px;
  width: 100%;

  margin-bottom: $nav-height;
}
body {
  padding: 0;
  margin: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

  display: flex;
  align-items: center;
  flex-flow: column;
}
.view{
    padding-top: 72px;
}
#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
