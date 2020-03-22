<template>
  <div class="App">
    <v-app-bar app color="#4d8c05" dark>
      <v-toolbar-title>
        <span class="font-weight-black">Mood @ Work</span>
      </v-toolbar-title>

      <v-spacer></v-spacer>
      <v-toolbar-side-icon name="logo" v-if="Tokenvalue" >
        <v-img class="mr-5" src="@/assets/logo.png" width="65px" @click="logout"></v-img>
      </v-toolbar-side-icon>
    </v-app-bar>
  </div>
</template>
<script  lang="ts">
/* tslint:disable */
import Vue from "vue";
import axios from "axios";
import Router from "vue-router";
import router from "../router";
import Snackbar from "../components/Snackbar.vue";

export default Vue.extend({
  data: () => ({
    cook: "",
    cookieName: "Vnext",

    text: "",
    
  }),
  components: {
    Snackbar
  },
  methods: {
    async logout() {
      axios
        .post("https://localhost:44380/api/SignOut")
        .then(resp => {
          this.cook = resp.data;
          this.$cookies.remove(this.cookieName, this.cook);
          this.$router.push("/"); 
        })

        .catch(function(error) {
          console.log(error);
        });
    }
  },
  computed:{
    
    Tokenvalue() {

      return   this.$cookies.get("Vnext");

    },
  }
});

</script>
