<template>
  <div class="landing">
    <div class="landing-upper">
      <h2>Otevřená databáze skatespotů pro nadšence</h2>
      <router-link to="/map"
        ><button class="btn-l btn-primary">Přejít na mapu</button></router-link
      >
      <video
        id="landing-upper-video"
        no-controls
        autoplay
        loop="true"
        plays-inline
      >
        <!-- <source type="video/mp4" src="@/assets/skate.mp4" /> -->
        <source type="video/webm" src="@/assets/video.webm" />
      </video>
    </div>
    <div class="landing-lower">
        <div class="statistics">
            <div class="statistics-content">
                <div class="statistics-content-number">{{ spots.toFixed(0) }}</div>
                <div class="statistics-content-description">skatespotů</div>
            </div>
            <div class="statistics-content" style="justify-content: center;">
                <div class="statistics-content-number">{{ users.toFixed(0)}}</div>
                <div class="statistics-content-description">uživatelů</div>
            </div>
            <div class="statistics-content" style="justify-content: flex-end;">
                <div class="statistics-content-number">{{ places.toFixed(0)}}</div>
                <div class="statistics-content-description">lokací</div>
            </div>
        </div>
      <div class="main-title">
        <h2>Náš projekt</h2>
      </div>
      <p>
        Náš projekt má za cíl zpříjemnit život všem nadšencům do skatingu, tím
        že budou mít možnost volně přidávat a prohlížet místa pro skating. Jsme
        si vědomi toho, že není jednoduché najít dobré místo pro skatování. Když
        se nějaké místo najde a chcete se o něj podělit se světem, tak naše
        aplikace je skvělá volba, která nabízí i volně přístupnou API.
      </p>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import gsap from "gsap";
import { StatisticsModel } from "../models/statistics-model";

export default Vue.extend({
  name: "LadingView",
  data: function () {
    return {
      stats: undefined as StatisticsModel | undefined,
      // tStats: undefined as StatisticsModel | undefined,
      spots: 0,
      users: 0,
      places: 0,
    };
  },
  created: async function () {
    const res = await axios.get(`${CONSTS.ENDPOINT}/data/getstatistics`);
    this.stats = res.data;
  },
  watch: {
    stats: function (newValue) {
      gsap.to(this.$data, { duration: 0.5, spots: newValue.spotCount });
      gsap.to(this.$data, { duration: 0.5, users: newValue.userCount });
      gsap.to(this.$data, { duration: 0.5, places: newValue.placeCount });
    },
  },
});
</script>

<style lang="scss" scoped>
@import "../../styles/variables/variables.scss";

.landing-upper {
  position: relative;
  overflow: hidden;
}
.statistics{
    display: flex;
    flex-flow: row;
    flex-wrap: no-wrap;
    border-radius: 8px;
    box-sizing: border-box;
    margin-top: 48px;
    height: auto;
    padding: 54px 64px;
    background-image: url('https://i.ibb.co/Zzjf78j/skate-banner.jpg');
    background-position: center;
    background-size: cover;
    flex-wrap: wrap;
    background-repeat: no-repeat;
    justify-content: space-between;
    &-content{
        flex: 1;
        width: min-content;
        display: flex;
        flex-flow: row;
        color: $secondary-color;
        align-items: center;
        &-number{
            font-size: 48px;
            font-weight: 500;
        }
        &-description{
            font-size: 22px;
            margin-left: 16px;
            margin-top: 12px;
        }
    }
}

@media screen and(max-width: $tablet-width) {
    .statistics{
        &-content{
            justify-content: center !important; 
        }
    }
}
#landing-upper-video {
  width: 100%;
  position: absolute;
  filter: brightness(0.4);
  object-fit: fill;
}
</style>