<template>

    <v-container>
        <v-content>
            <v-layout justify-center>
                <v-card color="#B2D3A3" shaped elevation="12" height=auto>
                    <v-toolbar color="#B2D3A3" flat>
                        <v-spacer></v-spacer>
                        <v-toolbar-title><span class="title">Se connecter</span></v-toolbar-title>
                        <v-spacer></v-spacer>
                    </v-toolbar>

                    <v-divider></v-divider>

                    <v-card-text>
                        <v-form>
                         

                            <v-text-field label="Pseudo"
                                          v-model="login"
                                          :rules="[rules.required]"
                                          color="#4d8c05"
                                          height="40"
                                          name="login"
                                          prepend-icon="person"
                                          type="text"></v-text-field>

                            <v-text-field label="Password"
                                          v-model="password"
                                        :rules="[rules.required, rules.min]"
                                         :type="show1 ? 'text' : 'password'"
                                          color="#4d8c05"
                                          height="40"
                                          name="password"
                                          prepend-icon="lock"
                                           :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                                         
                                           @click:append="show1 = !show1"></v-text-field>
                        </v-form>
                    </v-card-text>

                    <v-card-actions class="justify-center">
                        <v-btn small  color="#6DB041" dark rounded @click="logine">
                            <span>Valider</span>
                            <v-icon small right>done</v-icon>
                        </v-btn>
                    </v-card-actions>
                    <br>
<v-card-actions class="justify-center">
<router-link to="/signup">  <v-btn rounded  small color="#B2D3A3" ><span style="color:#4d8c05" >Crée un compte </span></v-btn></router-link>
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
    import Vue from 'vue'
    import axios from 'axios';
    import Router from 'vue-router';
import router from '../router';
import VueCookies from 'vue-cookies'

 export default Vue.extend({
    data: () => ({
         login: "",
         password: "",
           show1: false,
             rules: {
          required: (value: any) => !!value || 'Champ requis.',
          min: (v: string|any[]) => v.length >= 5 || 'Min 5 characters',
          },
        
     }),
     methods: {
         async logine() {
             axios.post('https://localhost:44380/api/Auths', {
                 Pseudo: this.login,
                 Password: this.password,
             },)
               .then(resp => {
      const token = resp.data.token
      localStorage.setItem('user-token', token) // store the token in localstorage
      
      console.log("cookie"+this.$cookies)
      console.log(resp.headers)


      this.$router.push('/Mood')
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
             .catch(function (error) {
                 console.log(error);
             });
         }

        },
 })
/* tslint:disable */
</script>
