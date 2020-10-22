<template>
  <div class="landing">
    <div class="landing-upper">
      <h2>Otevřená databáze skatespotů pro nadšence</h2>
      <router-link to="/map"
        ><button class="btn-l btn-primary">Přejít na mapu</button></router-link
      >
      <video
        id="landing-upper-video"
        style="width: 100%; height: 100%"
        no-controls
        autoplay
        src="../videos/skate.mp4"
      ></video>
    </div>
    <div class="landing-lower">
      <div class="main-title">
        <h2>Náš projekt</h2>
      </div>
      <p>
        Náš projekt má za cíl zpříjemnit život všem nadšencům do skatingu, tím
        že budou mít možnost volně přidávat a prohlížet místa pro skating. Jsme
        si vědomi toho, že není jednoduché najít dobré místo pro skatování. Když
        se nějaké místo najde a chcete se o něj podělit se světem, tak naše
        aplikace je skvělá volba která nabízí i volně přístupnou API.
      </p>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "LadingView",
});
</script>

<style lang="scss" scoped>
@import "../../styles/variables/variables.scss";
#landing-upper-video {
  width: 100%;
  position: absolute;
  object-fit: fill;
}
</style>
