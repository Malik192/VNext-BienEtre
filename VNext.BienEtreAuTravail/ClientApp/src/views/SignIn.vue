<template>
  <v-container>
    <v-content>
      <v-layout justify-center>
        <v-card color="#B2D3A3" shaped elevation="12" height="auto">
          <v-toolbar color="#B2D3A3" flat>
            <v-spacer></v-spacer>
            <v-toolbar-title>
              <span class="title">Se connecter</span>
            </v-toolbar-title>
            <v-spacer></v-spacer>
          </v-toolbar>

          <v-divider></v-divider>

          <v-card-text>
            <v-form>
              <v-text-field
                label="Pseudo"
                v-model="login"
                :rules="[rules.required]"
                color="#4d8c05"
                height="40"
                name="login"
                prepend-icon="person"
                type="text"
              ></v-text-field>

              <v-text-field
                label="Password"
                v-model="password"
                :rules="[rules.required, rules.min]"
                :type="show1 ? 'text' : 'password'"
                color="#4d8c05"
                height="40"
                name="password"
                prepend-icon="lock"
                :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                @click:append="show1 = !show1"
              ></v-text-field>
            </v-form>
          </v-card-text>

          <v-card-actions class="justify-center">
            <v-btn small color="#6DB041" dark rounded @click="Authentification">
              <span>Valider</span>
              <v-icon small right>done</v-icon>
            </v-btn>
          </v-card-actions>
          <br />
          <v-card-actions class="justify-center">
            <router-link to="/signup">
              <v-btn rounded small color="#B2D3A3">
                <span style="color:#4d8c05">Crée un compte</span>
              </v-btn>
            </router-link>
          </v-card-actions>
          <v-snackbar v-model="snackbar">
            {{ text }}
            <v-btn color="#1DB954" text @click="snackbar = false">
              <v-icon medium right>cancel</v-icon>
            </v-btn>
          </v-snackbar>
        </v-card>
      </v-layout>
    </v-content>
  </v-container>
</template>
<style>
.v-card:not(.v-sheet--tile):not(.v-card--shaped) {
  border-radius: 40px;
}
</style>
<script src="./SignIn"  lang="ts">

/* tslint:disable */

import Vue from "vue";
import axios from "axios";
import Router from "vue-router";
import router from "../router";
import Token from "./SignIn";
import Snackbar from "../components/Snackbar.vue"; 

export default Vue.extend({
  
  data: () => ({
    login: "",
    password: "",
    cook: "",
    cookieName: "Vnext",
    show1: false,
    text: "",
    snackbar: false,
    rules: {
      required: (value: any) => !!value || "Champ requis.",
      min: (v: string | any[]) => v.length >= 5 || "Min 5 characters"
    }
  }),
  components: {
    Snackbar,
    
  },
  
  methods: {
    async Authentification() {
   

      //   await this.$store.dispatch("SetToken",this.login)
      //await p.AddToken();
    }
  }
})
 
/*
  methods: {
    
  }
});
*/
/* tslint:disable */
</script>
