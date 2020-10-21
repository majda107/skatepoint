<template>
    <div class="main-wrapper">
        <div class="main-title">
            <h2>Moje spoty</h2>
        </div>
        <div class="cards">
            <SpotComponent/>
            <SpotComponent/>
            <SpotComponent/>
            <SpotComponent/>
        </div>
    </div>
</template>

<script>
import SpotComponent from "../components/SpotComponent.vue"

export default {
    name: "ProfileView",
    components: {
        SpotComponent,
    }
}
</script>

<style lang="scss">

@import "../../styles/main.scss";

.cards{
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
    width: 100%;
}

@media screen and (max-width: $mobile-width){
    .cards{
        justify-content: flex-start;
    }
}

</style>