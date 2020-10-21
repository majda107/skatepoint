<template>
  <div class="card">
    <img
      src="https://scontent-prg1-1.xx.fbcdn.net/v/t1.0-9/84401281_1090915061243813_1250138544618340352_n.jpg?_nc_cat=101&ccb=2&_nc_sid=e3f864&_nc_ohc=UMEKEVmYe9kAX9p0a0L&_nc_ht=scontent-prg1-1.xx&oh=a3a318e945c137d959cff4f257049188&oe=5FB6D6EB"
      alt="Card image"
    />
    <div class="card-content">
      <h3>{{ point.name }}</h3>
      <span class="mt-8">{{ point.type }}</span>
      <span class="medium" style="margin-top: 4px">19 lajků</span>
      <button class="btn-primary btn-m mt-24">Odstranit</button>
    </div>
  </div>
</template>

<script lang="ts">
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