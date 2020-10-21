<template>
  <div>
    <div v-if="fetched && schoolInfections != undefined">
      <div v-html="schoolInfections.notice"></div>
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

export default Vue.extend({
  name: "SchoolView",
  data: function () {
    return {
      fetched: false,
      schoolInfections: undefined as SchoolInfectionModel | undefined,
    };
  },

  created: async function () {
    const ico = this.$route.params["ico"];
    const res = await axios.get(
      `${CONSTS.ENDPOINT}/school/getinfections?ico=${ico}`
    );

    this.schoolInfections = res.data;
    this.fetched = true;
  },
});
</script>