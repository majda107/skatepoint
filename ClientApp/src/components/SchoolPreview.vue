<template>
  <div class="result">
      <h3 class="medium" style="text-align: left;">Střední škola a vyšší odborná škola aplikované kybernetiky s. r. o.</h3>
      <span class="alert medium">Velká míra nakažených v Okresu!</span>
      <span class="mt-8">Aktuální způsob výuky: distanční výuka</span>
      <span>Počet nakažených: 21</span>
      <span class="text-grey" style="margin-top: 12px;">Hradec Králové, okres Hradec Králové</span>
  </div>
</template>

<script>
export default {
    name: "SchoolPreview",
}
</script>

<style scoped lang="scss">
@import "../../styles/main.scss";
    .result{
        display: flex;
        cursor: pointer;
        flex-flow: column;
        align-items: flex-start;
        width: 100%;
        padding: 16px 0;
        height: auto;
        border-bottom: solid 1px $grey-text;
        h3{
            font-size: 24px;
            font-weight: 500;
        }
    }
</style>