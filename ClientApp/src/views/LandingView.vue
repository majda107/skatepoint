<template>
  <div class="landing main-wrapper">
    <div class="landing-upper">
      <h1>Otevřená databáze skatespotů pro lidi</h1>
      <router-link to="/search"
        ><button class="btn-l btn-primary">Přejít na mapu</button></router-link
      >
    </div>
    <div class="landing-lower">
      <h2>Náš projekt</h2>
      <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu posuere
        dolor. Donec mi eros, dignissim volutpat sodales vel, tempus vitae eros.
        Integer volutpat auctor lacus, a ornare mi iaculis sit amet. Donec vel
        diam ullamcorper, pharetra felis sit amet, fringilla enim. Duis maximus
        orci nisl. Class aptent taciti sociosqu ad litora torquent per conubia
        nostra, per inceptos himenaeos. Integer cursus, lacus vel pharetra
        faucibus, orci ligula facilisis ante, non imperdiet velit diam id leo.
        Mauris sed luctus elit, a posuere est. Etiam sodales libero ac
        ullamcorper vehicula. Maecenas sollicitudin sollicitudin odio non
        aliquet. Orci varius natoque penatibus et magnis dis parturient montes,
        nascetur ridiculus mus. Maecenas sit amet lobortis quam. Sed feugiat at
        dolor a fermentum. Cras eget tortor in mi imperdiet sollicitudin.
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
h1 {
  text-align: center;
}
.landing {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  .landing-upper {
    height: 350px;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    // background-image: url('https://imgur.com/8Qbi89e.jpg');
    background-color: #c4c4c4;
    width: 100vw;
    h1 {
      margin-bottom: 30px;
    }
  }
  .landing-lower {
    height: 300px;
    display: flex;
    justify-content: center;
    flex-direction: column;
    h2 {
      margin-bottom: 10px;
    }
  }
}
</style>