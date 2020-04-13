<template>
  <v-container>
    <v-content>
      <v-layout justify-center>
        <v-card color="#B2D3A3"  shaped elevation="12" height="auto">
             <v-toolbar color="#B2D3A3" flat>
            <v-spacer></v-spacer>
            <v-toolbar-title>
              <span class="title">S’inscrire</span>
            </v-toolbar-title>
            <v-spacer></v-spacer>
          </v-toolbar>
        {{it}}
{{items}}
          <v-divider></v-divider>
           
          <v-card-text>
            <v-col>
      
              <v-select
                :items="items" 
                value="departement"
                height="40"
                label="Departement"
                name="departement"
                color="#4d8c05"
               @change="onChange($event)"
                prepend-icon="group"
                :menu-props="{ top: true, offsetY: true }"
              >
              </v-select>
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
            <v-btn small  color="#6DB041" dark rounded @click="logine">
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
    items: [],
    it:[],
    login: "",
    password: "",
    departement:"",
    show1: false,
    id:0,
    rules: {
      required: (value: any) => !!value || "Champ requis.",
      min: (v: string | any[]) => v.length >= 5 || "Min 5 characters"
    }
  }),
    
  mounted(){
     
      axios
        .get("https://localhost:44380/api/dep")
        .then(resp => {
          resp.data.forEach(element => {
            this.it.push({id: element.IdDepartement, departement: element.NomDepartement})
          });
          
       this.it.forEach(element => {
         this.items.push(element.departement)
         
       });
        })
        .catch(function(error) {
          console.log(error);
        });
    
  },

  methods: {
    onChange(event:string) {
      this.departement=event
      this.it.forEach(element => {
        if (element.departement==event) {
          this.id=element.id
          
        }
      });

        },
 
    async logine() {
      console.log(this.departement)
      axios
        .post("https://localhost:44380/api/User", {
          Pseudo: this.login,
          Password: this.password,
          IdDepartement:this.id
          
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
