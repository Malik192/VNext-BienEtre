<template>
  <v-app id="app">
    <link href="https://fonts.googleapis.com/css?family=Material+Icons" rel="stylesheet" />

    <v-content>
     <Navbar></Navbar>
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script lang="ts">
/* tslint:disable */
import Vue from 'vue';
import Navbar from "@/components/Navbar.vue";

export default Vue.extend({
  name: 'App',

  components: {
    Navbar,
  }
});
/* tslint:disable */
</script>

