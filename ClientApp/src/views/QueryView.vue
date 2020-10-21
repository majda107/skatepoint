<template>
  <div class="main-wrapper">
    <div class="main-title">
        <h2>Vyhledání školy</h2>
        <button class="btn-s btn-primary" style="margin-left: 24px;">Filtry</button>
    </div>
    <div class="search">
      <input type="text" class="search-i" v-model="query" placeholder="Vyhledej školu"/>
      <button class="btn-l btn-secondary" style="margin-left: 16px;" @click="search()">Search</button>
    </div>
    <div class="results">
        <SchoolPreview/>
        <SchoolPreview/>
        <SchoolPreview/>
    </div>
    <!-- 
    <ul class="results">
        <li
        v-for="(school, i, k) in schools"
        :key="k"
        @click="navigateTo(school)"
      >
        {{ school.fullName }}
      </li>
    </ul> -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SchoolModel } from "../models/school-model";

import SchoolPreview from "../components/SchoolPreview.vue"

export default Vue.extend({
  data: function() {
    return {
      query: "",
      schools: [] as SchoolModel[],
    };
  },
  components:{
      SchoolPreview,
  },

  methods: {
    search: async function() {
      const res = await axios.get(
        `${CONSTS.ENDPOINT}/school/searchico?name=${this.query}`
      );

      this.schools = res.data;
    },
    navigateTo: async function(school: SchoolModel) {
      this.$router.push(`/school/${school.ico}`);
    },
  },
});
</script>

<style lang="scss" scoped>
.search{
    width: 100%;
    display: flex;
    flex-flow: row;
    margin-bottom: 32px;
    input{
        width: 100% !important;
    }
}
</style>