<template>
  <div class="main-wrapper">
    <!-- <template v-if="getLoggedIn"> -->
    <div class="main-title">
      <h2>Přidání místa pro skating</h2>
    </div>
    <div class="creator">
      <div class="creator-left">
        <form>
          <div class="auto-fill">
            <div class="auto-fill-input">
              <label>Name</label>
              <input
                type="text"
                class="mt-4"
                v-model="name"
                v-debounce:500ms="debounce"
              />
            </div>
            <ul class="auto-fill-results" v-show="places.length > 0">
              <li
                v-for="(p, i, k) in places"
                :key="k"
                @click="chooseName(p.name)"
              >
                {{ p.name }} | {{ p.type }}
              </li>
            </ul>
          </div>

          <label class="mt-8">Type</label>
          <input type="text" class="mt-4" v-model="type" />
          <label class="mt-8">Description</label>
          <textarea rows="3" class="mt-4" v-model="description" />

          <div class="file-input mt-16">
            <input type="file" ref="fileInput" id="file" />
            <label for="file">Nahrát obrázek</label>
            <span style="margin-left: 24px">img.jpg</span>
          </div>

          <button
            class="btn-m mt-24 btn-secondary"
            type="button"
            @click="upload"
          >
            Upload
          </button>
        </form>
      </div>
      <div class="creator-right">
        <div class="map">
          <map-component v-on:marker="setMarker"></map-component>
        </div>
        <p class="mt-16">
          <span class="medium">lat:</span> {{ lat }}
          <span class="medium">lng:</span> {{ lng }}
        </p>
      </div>
    </div>
    <!-- </template>
    <template v-else>
      <span>... please login</span>
    </template> -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";

import vueDebounce from "vue-debounce";
Vue.use(vueDebounce);

import MapComponent from "../components/MapComponent.vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "../models/skate-point-model";
import { KnownPlaceModel } from "../models/known-place-model";
import { mapGetters } from "vuex";
import router from "@/router";

export default Vue.extend({
  name: "CreatorView",
  components: {
    MapComponent,
  },
  data: function () {
    return {
      name: "",
      type: "",
      description: "",
      lat: 0,
      lng: 0,
      places: [] as KnownPlaceModel[],
    };
  },

  methods: {
    upload: async function () {
      const fileInput = this.$refs.fileInput as HTMLInputElement;
      const file = fileInput?.files?.item(0) ?? null;

      if (file == null) {
        console.log("Invalid file count!");
        return;
      }

      let res = await axios.post(
        `${CONSTS.ENDPOINT}/skate/addpoint`,
        {
          name: this.name,
          lat: this.lat,
          lng: this.lng,
          description: this.description,
          type: this.type,
        } as SkatePointModel,
        {
          headers: {
            Authorization: `Bearer ${this.getToken}`,
          },
        }
      );

      console.log(res.data);

      const form = new FormData();
      form.append("files", file);
      form.append("id", res.data.id);

      res = await axios.put(`${CONSTS.ENDPOINT}/skate/putpointimage`, form, {
        headers: {
          Authorization: `Bearer ${this.getToken}`,
        },
      });

      this.$router.push("/map");
    },
    setMarker: async function (latlng: any) {
      console.log(latlng);
      this.lat = latlng.lat;
      this.lng = latlng.lng;
    },
    debounce: async function () {
      const res = await axios.get(
        `${CONSTS.ENDPOINT}/skate/getknownplaces?name=${this.name}`
      );

      const places: KnownPlaceModel[] = res.data as KnownPlaceModel[];
      this.places = places;
    },
    chooseName: function (s: string) {
      this.name = s;
      this.places = [];
    },
  },

  created: async function () {
    // if (!this.getLoggedIn) {
    //   this.$router.push("/login");
    //   return;
    // }
  },

  computed: {
    ...mapGetters(["getLoggedIn", "getToken"]),
  },
});
</script>

<style lang="scss" scoped>
// .creator {
//   display: grid;
//   grid-template-columns: 1fr auto;
//   grid-template-rows: auto;
// }

@import "../../styles/main.scss";

.creator {
  display: flex;
  flex-flow: row;
  &-left {
    flex: 1;
    margin-bottom: 32px;
    form {
      margin-right: 48px;
    }
  }
  &-right {
    flex: 1;
    display: flex;
    flex-flow: column;
  }
}

.auto-fill {
  position: relative;
  &-input {
    display: flex;
    flex-flow: column;
    width: 100%;
  }
  ul {
    list-style: none;
    position: absolute;
    background-color: $secondary-color;
    @include shadow-outset;
    width: 100%;
    margin: 8px 0 0;
    padding: 8px 24px;
    box-sizing: border-box;
    @include input-border;
    border-radius: 8px;
    overflow-y: auto;
    max-height: 420px;
    li {
      padding: 16px 0;
      border-bottom: 1px solid #c8c8c8;
      cursor: pointer;
      transition: color 0.2s;
      &:hover {
        color: $primary-color;
      }
      &:last-of-type {
        border-bottom: none;
      }
    }
  }
}
.map {
  width: 100%;
  height: 420px;
  display: grid;
  grid-template-columns: 1fr auto;
  grid-template-rows: auto;
}

form {
  display: flex;
  flex-flow: column;
}

@media screen and (max-width: $mobile-width) {
  .creator {
    flex-flow: column-reverse;
    &-left {
      form {
        margin: 0;
      }
    }
    &-right {
      margin-bottom: 32px;
    }
  }
}
</style>
