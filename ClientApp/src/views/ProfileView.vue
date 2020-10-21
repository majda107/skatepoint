<template>
    <div class="main-wrapper">
        <div class="main-title">
            <h2>Moje spoty</h2>
        </div>
        <div class="cards">
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

.cards{
    display: flex;
    flex-flow: row;
    flex-wrap: wrap;
    justify-content: space-between;
    width: 100%;
}

</style>