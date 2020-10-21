<template>
  <div>
    <div v-if="fetched && school != undefined">
      {{ school.notice }}
    </div>
    <div v-else>
      <span>Loading...</span>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { SchoolInfectionModel } from "../models/school-infection-model";
export default Vue.extend({
  name: "SchoolView",
  data: function () {
    return {
      fetched: false,
      school: undefined as SchoolInfectionModel | undefined,
    };
  },
});
</script>