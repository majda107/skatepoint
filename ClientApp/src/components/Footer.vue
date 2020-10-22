<template>
  <section class="footer">Hackathon 2020. Tým Nepobírám.
    <div class="footer-links">
      <router-link to="/api">API</router-link>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "Footer",
});
</script>

<style scoped lang="scss">
@import "../../styles/main.scss";
</style>