<template>
  <div class="main-wrapper">
    <template v-if="getLoggedIn">
      <div class="main-title">
        <h2>Moje spoty</h2>
      </div>
      <div class="cards">
        <SpotComponent
          :point="p"
          v-for="(p, i, k) in points"
          :key="k"
          v-on:remove="remove(p)"
        />
      </div>
    </template>
    <template v-else>
      <span>Please login...</span>
    </template>
  </div>
</template>


<script lang="ts">
import Vue from "vue";
import { mapGetters } from "vuex";
import SpotComponent from "../components/SpotComponent.vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "../models/skate-point-model";

export default Vue.extend({
  name: "ProfileView",
  components: {
    SpotComponent,
  },
  computed: {
    ...mapGetters(["getLoggedIn", "getToken"]),
  },
  data: function () {
    return {
      points: [] as SkatePointModel[],
    };
  },
  created: async function () {
    if (!this.getLoggedIn) {
      this.$router.push("/login");
      return;
    }

    const res = await axios.get(`${CONSTS.ENDPOINT}/skate/getmypoints`, {
      headers: {
        Authorization: `Bearer ${this.getToken}`,
      },
    });

    console.log(res.data);
    this.points = res.data;
  },
  methods: {
    remove: async function (p: SkatePointModel) {
      try {
        const res = await axios.delete(
          `${CONSTS.ENDPOINT}/skate/deletepoint?id=${p.id}`
        );

        this.points.splice(this.points.indexOf(p), 1);
      } catch (e) {
        console.log(e);
      }
    },
  },
});
</script>

<style lang="scss">
.cards {
  display: flex;
  flex-flow: row;
  flex-wrap: wrap;
  justify-content: space-around;
  width: 100%;
}
</style>