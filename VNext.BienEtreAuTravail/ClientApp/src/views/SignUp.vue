<template>
  <v-container>
    <v-content>
      <v-layout justify-center>
        <v-card color="#B2D3A3" flat shaped elevation="12" height="auto">
          <v-toolbar color="#B2D3A3" flat>
            <v-spacer></v-spacer>
            <v-toolbar-title>
              <span class="title">S’inscrire</span>
            </v-toolbar-title>
            <v-spacer></v-spacer>
          </v-toolbar>

          <v-divider></v-divider>

          <v-card-text>
            <v-col>
              <v-select
                :items="items"
                flat
                height="40"
                label="Departement"
                name="item"
                color="#4d8c05"
                prepend-icon="group"
                :menu-props="{ top: true, offsetY: true }"
              ></v-select>
            </v-col>

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
          </v-card-text>

          <v-card-actions class="justify-center">
            <v-btn small flat color="#6DB041" dark rounded @click="logine">
              <span>Valider</span>
              <v-icon small right>done</v-icon>
            </v-btn>
          </v-card-actions>
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
<script lang="ts">
/* tslint:disable */
import Vue from "vue";
import axios from "axios";
import Router from "vue-router";
import router from "../router";
import VueCookies from "vue-cookies";

export default Vue.extend({
  data: () => ({
    items: ["RH", "UX", "Dev", "Autre"],
    login: "",
    password: "",
    show1: false,
    rules: {
      required: (value: any) => !!value || "Champ requis.",
      min: (v: string | any[]) => v.length >= 5 || "Min 5 characters"
    }
  }),
  methods: {
    async logine() {
      axios
        .post("https://localhost:44380/api/User", {
          Pseudo: this.login,
          Password: this.password
        })
        .then(resp => {
          this.$router.push("/");
          //    resolve(resp)
        })
        /*      .then(function (response) {
                      console.log(response);
                      if(response.status==200){
                           router.push("/Mood");
                      }
                      else{
                          console.log("Erreur")
                      }
                 })*/
        .catch(function(error) {
          console.log(error);
        });
    }
  }
});
/* tslint:disable */
</script>
