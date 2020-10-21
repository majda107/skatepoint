<template>
  <div>
    <div v-if="fetched && schoolInfections != undefined" class="school">
      <h1>{{ schoolInfections.school.fullName }}</h1>

      <span
        v-if="schoolInfections.level == 'high'"
        style="display: block"
        class="alert"
        >Vysoký počet nakažených</span
      >
      <span
        v-if="schoolInfections.level == 'low'"
        style="display: block"
        class="success"
        >Nízký počet nakažených</span
      >

      <div class="statistics-wrapper">
        <div class="statistics" v-if="infection">
          <h2>
            Koronavirus statistiky v okresu
            {{ schoolInfections.school.province }}
          </h2>
          <div class="statistics-data">
            <img
              v-if="schoolInfections.level == 'high'"
              src="@/assets/sad.svg"
            />
            <img
              v-if="schoolInfections.level == 'low'"
              src="@/assets/happy.svg"
            />
            <div>
              <span>Nakažení</span>
              <span class="warning">{{ infection.infected }}</span>
            </div>
            <div>
              <span>Vyléčení</span>
              <span class="success">{{ infection.recovered }}</span>
            </div>
            <div>
              <span>Úmrtí</span>
              <span class="alert">{{ infection.died }}</span>
            </div>
          </div>
        </div>

        <div class="statistics">
          <h2>Počet nakažených ve škole</h2>
          <div class="statistics-data">
            <span class="simple">69</span>
          </div>
        </div>
      </div>

      <h2>Výhláška pro okres {{ schoolInfections.school.province }}</h2>
      <div class="notice" v-html="schoolInfections.notice"></div>

      <h2>Výhláška ředitele školy</h2>
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

      <div class="contact">
        <div class="contact-address">
          <h2>Informace o škole</h2>
          <ul>
            <li><a>Webové stránky školy</a></li>
            <li>
              <span>Vedení: {{ schoolInfections.school.principalName }}</span>
            </li>
            <li>
              <span>IČO: {{ schoolInfections.school.ico }}</span>
            </li>
          </ul>

          <h3>Adresa</h3>
          <p>{{ schoolInfections.school.address }}</p>
        </div>
        <div class="contact-map"></div>
      </div>
    </div>
    <div v-else>
      <span>Loading...</span>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { SchoolInfectionModel } from "../models/school-infection-model";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SchoolModel } from "@/models/school-model";
import { ProvinceInfectionModel } from "@/models/province-infection-model";

export default Vue.extend({
  name: "SchoolView",
  data: function () {
    return {
      fetched: false,
      schoolInfections: undefined as SchoolInfectionModel | undefined,
      infection: undefined as ProvinceInfectionModel | undefined,
    };
  },

  created: async function () {
    const ico = this.$route.params["ico"];
    const res = await axios.get(
      `${CONSTS.ENDPOINT}/school/getinfections?ico=${ico}`
    );

    this.schoolInfections = res.data;
    if (this.schoolInfections && this.schoolInfections.infections.length > 0) {
      this.infection = this.schoolInfections.infections[
        this.schoolInfections.infections.length - 1
      ];
    }

    this.fetched = true;
  },
});
</script>

<style lang="scss" scoped>
// @import "../../styles/variables/variables.scss";

.contact {
  display: grid;
  grid-template-columns: 1fr 600px;
  grid-template-rows: auto;

  &-address {
    & > ul {
      margin-top: 10px;
    }

    & > h3 {
      margin-top: 18px;
      margin-bottom: 8px;
    }
  }

  &-map {
    background-color: gray;
    width: 600px;
    height: 340px;
  }
}

.school {
  & > * {
    margin-top: 28px;
  }

  * {
    text-align: left;
  }
}

.notice {
  //   max-height: 260px;
  //   overflow-y: scroll;
  //   overflow-x: hidden;
  ::v-deep * {
    color: gray;
    font-size: 0.9rem;
    font-weight: normal;
  }
  
  ::v-deep hr {
      display: none;
  }
}

p {
  font-size: 0.9rem;
  color: gray;
}

.statistics-wrapper {
  display: flex;
  flex-flow: row;
  margin-top: 40px;

  & > * {
    margin-right: 32px;
  }
}

.statistics {
  background-color: #1d1d1d;
  padding: 16px 26px;
  border-radius: 8px;

  display: flex;
  flex-flow: column;
  width: fit-content;

  & > h2 {
    font-size: 1.375rem;
  }

  * {
    // color: $secondary-color;
    color: white;
  }

  &-data {
    display: flex;
    flex-flow: row;
    margin-top: 18px;

    & > img {
      width: 64px;
    }

    & > div {
      display: flex;
      flex-flow: column;

      & > span {
        font-size: 1.25rem;
        font-weight: 500;
      }
    }

    & > .simple {
      font-size: 2.25rem;
    }

    & > * {
      margin-right: 22px;
    }
  }
}
</style>