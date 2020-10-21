<template>
  <div>
    <input type="text" v-model="query" />
    <button @click="search()">Search</button>

    <hr />

    <ul>
      <li v-for="(school, i, k) in schools" :key="k">
        {{ school.fullName }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SchoolModel } from "../models/school-model";

export default Vue.extend({
  data: function () {
    return {
      query: "",
      schools: [] as SchoolModel[],
    };
  },

  methods: {
    search: async function () {
      const res = await axios.get(
        `${CONSTS.ENDPOINT}/school/searchico?name=${this.query}`
      );

      this.schools = res.data;
    },
  },
});
</script>