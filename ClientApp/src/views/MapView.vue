<template>
  <div class="main-wrapper">
    <div class="main-title">
      <h2>Mapa spotů</h2>
    </div>
    <div class="map" ref="map">
      <!-- <l-map :zoom="zoom" :center="center" @click="addMarker"> -->
      <l-map :zoom="zoom" :center="center">
        <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
        <!-- <l-marker :lat-lng="marker" @click="selectMarker"></l-marker> -->

        <l-marker
          :lat-lng="p.marker"
          v-for="(p, i, k) in points"
          :key="k"
          @click="selectMarker(p.point)"
        ></l-marker>
      </l-map>
    </div>
    <div class="split mt-32" v-if="selected != undefined">
      <div class="split-left">
        <h3>{{ selected.name }}</h3>
        <h4 class="medium mt-16">Typ</h4>
        <p class="mt-4">{{ selected.type }}</p>
        <h4 class="mt-16">Popisek</h4>
        <p class="mt-4">{{ selected.description }}</p>
        <span>lat: {{ selected.lat }} lng: {{ selected.lng }}</span>
        <div class="inline-f mt-24">
          <h4>Hodnocení</h4>
          <button class="btn-s btn-primary" style="margin-left: 24px">
            To se mi líbí
          </button>
        </div>
        <p class="mt-8 t-primary medium" style="font-size: 20px">24 likes</p>
      </div>
      <div class="split-right">
        <img class="mt-48" :src="getImageUrl(selected)" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
import axios from "axios";
import * as V2L from "vue2-leaflet";

import L, { MarkerOptions } from "leaflet";
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "@/models/skate-point-model";
import { PairedPointModel } from "@/models/paired-point-model";

// eslint-disable-next-line
delete (L.Icon.Default.prototype as any)._getIconUrl;
// eslint-disable-next-line
L.Icon.Default.mergeOptions({
  iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
  iconUrl: require("leaflet/dist/images/marker-icon.png"),
  shadowUrl: require("leaflet/dist/images/marker-shadow.png"),
});

export default Vue.extend({
  components: {
    LMap,
    LTileLayer,
    LMarker,
  },

  data() {
    return {
      zoom: 13,
      center: L.latLng(47.41322, -1.219482),
      url: "http://{s}.tile.osm.org/{z}/{x}/{y}.png",
      attribution:
        '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      // marker: L.latLng(47.41322, -1.219482),
      points: [] as PairedPointModel[],
      selected: undefined as SkatePointModel | undefined,
    };
  },

  created: async function () {
    // const container = this.$refs.map as HTMLElement;
    // container.appendChild(map.show());
    const res = await axios.get(`${CONSTS.ENDPOINT}/skate/getpoints`);

    const points: SkatePointModel[] = res.data as SkatePointModel[];
    this.points = points.map((p) => {
      return {
        marker: L.latLng(p.lat, p.lng),
        point: p,
      } as PairedPointModel;
    });
  },

  methods: {
    selectMarker: function (m: SkatePointModel) {
      console.log(m);
      this.selected = m;
    },
    getImageUrl: function (p: SkatePointModel) {
      if (p.image?.startsWith("http")) return p.image;
      return CONSTS.ENDPOINT + "/images/" + p.image;
    },
  },
});
</script>

<style lang="scss" scoped>
@import "~leaflet/dist/leaflet.css";
@import "../../styles/main.scss";

.map {
  width: 100%;
  height: 420px;
}
.split {
  display: flex;
  flex-flow: row;
  width: 100%;
  &-left {
    flex: 1;
  }
  &-right {
    flex: 1;
    text-align: end;
    padding: 0 0 0 64px;
    img {
      width: 100%;
      max-height: 320px;
      object-fit: cover;
    }
  }
}

@media screen and (max-width: $tablet-width) {
  .split {
    flex-flow: column;
    &-right {
      padding: 0;
    }
  }
}
</style>