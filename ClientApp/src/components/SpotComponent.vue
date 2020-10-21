<template>
  <div class="card">
    <img :src="getImageUrl(point)" />
    <div class="card-content">
      <h3>{{ point.name }}</h3>
      <span class="mt-8">{{ point.type }}</span>
      <span class="medium" style="margin-top: 4px">19 lajků</span>
      <button class="btn-primary btn-m mt-24" @click="remove">Odstranit</button>
    </div>
  </div>
</template>

<script lang="ts">
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "@/models/skate-point-model";
import Vue from "vue";
export default Vue.extend({
  name: "SpotComponent",
  props: {
    point: {
      type: Object as () => SkatePointModel,
      required: true,
    },
  },
  methods: {
    remove: function () {
      this.$emit("remove");
    },
    getImageUrl: function (p: SkatePointModel) {
      return CONSTS.ENDPOINT + "/images/" + p.image;
    },
  },
});
</script>

<style lang="scss" scoped>
@import "../../styles/main.scss";

.card {
  display: flex;
  flex-flow: column;
  background-color: $secondary-color;
  @include shadow-outset;
  border: solid inset 1px rgba(0, 0, 0, 0.15);
  border-radius: 8px;
  cursor: pointer;
  max-width: 350px;
  margin-bottom: 48px;
  img {
    width: 100%;
    height: 180px;
    object-fit: cover;
    border-radius: 8px 8px 0 0;
  }
  &-content {
    padding: 16px 24px 24px;
    display: flex;
    flex-flow: column;
    h3 {
      font-size: 20px;
      font-weight: 500;
    }
  }
}
</style>