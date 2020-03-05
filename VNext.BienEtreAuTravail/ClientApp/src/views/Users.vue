<template >
  <div class="App">
    <h1 class="subheading grey--text">Team members</h1>
    <v-container class="my-5">
      <v-content>
        <v-layout row wrap>
          <v-flex xs12 sm6 md4 lg3 v-for="(post,i) in posts" v-model="posts" v-bind:key="i">
            <v-card flat class="text-xs-center ma-3" elevation="5" v-bind:key="componentKey">
              {{componentKey}}
              <v-card-actions>
                <v-responsive class="pt-4">
                  <v-avatar size="100">
                    <img src="@/assets/avatar.png" />
                  </v-avatar>
                </v-responsive>
                <v-spacer></v-spacer>
                <v-btn text color="grey" style="min-width:20px">
                  <v-icon medium left color="#1DB954">cloud_upload</v-icon>
                </v-btn>
              </v-card-actions>
              <v-card-text>
                <div class="subheading">{{ post.IdEmployee }}</div>
                <div class="subheading">{{ post.Pseudo }} + {{i}}</div>
              </v-card-text>

              <v-card-actions>
                <v-btn text color="grey">
                  <v-icon small left color="#1DB954">message</v-icon>
                  <span>Contacter</span>
                </v-btn>
                <v-spacer></v-spacer>
                <v-dialog v-model="dialog" ref="popup" persistent max-width="600px">
                  <template v-slot:activator="{ on }">
                    <v-btn
                      text
                      color="grey"
                      style="margin-left:0px ; padding:0 0px"
                      @click="openDialog(post)"
                      v-on="on"
                    >
                      <v-icon medium left color="#1DB954">edit</v-icon>
                    </v-btn>
                  </template>
                  <v-card>
                    <v-card-title>
                      <span class="headline">User Profile</span>
                    </v-card-title>
                    <v-card-text>
                      <v-container>
                        <v-row>
                          <v-col cols="12" sm="12" md="12">
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
                          </v-col>

                          <v-col cols="12" sm="12" md="12">
                            <v-text-field
                              label="Password"
                              v-model="password"
                              :rules="[rules.required, rules.min]"
                             
                              :type="show1 ? 'text' : 'password'"
                              color="#4d8c05"
                              height="40"
                           
                              prepend-icon="lock"
                              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                              @click:append="show1 = !show1"
                            ></v-text-field>
                          </v-col>

                          <v-col cols="12" sm="6">
                            <v-autocomplete></v-autocomplete>
                          </v-col>
                        </v-row>
                      </v-container>
                      <small>*Modification de profile utilisateur</small>
                    </v-card-text>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="#6DB041" text @click="dialog = false">
                        <v-icon large right>cancel</v-icon>
                      </v-btn>
                      <v-btn color="#6DB041" text @click="save(post)">
                        <v-icon large right>done</v-icon>
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-dialog>

                <v-btn
                  text
                  color="grey"
                  style="margin-left:0px ;min-width:0px"
                  @click="supprimer(post, i)"
                >
                  <v-icon medium left color="#1DB954">delete_forever</v-icon>
                </v-btn>

                <v-snackbar v-model="snackbar">
                  {{ text }}
                  <v-btn color="#1DB954" text @click="snackbar = false">
                    <v-icon medium right>cancel</v-icon>
                  </v-btn>
                </v-snackbar>
              </v-card-actions>
            </v-card>
          </v-flex>
         
        </v-layout>
      </v-content>
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
//import {repositoryFactory} from '@/repositories/RepositoryFactory'
//var PostsRepository=repositoryFactory.get('users')
import axios from "axios";

export default Vue.extend({
  name: "App",
  data() {
    return {
      id: 0,
      posts: [],
      errors: [],
      url: `https://localhost:44380/api/User`,
      login: "",
      password: "",
      componentKey: 0,

      dialog: false,
      show1: false,
      rules: {
        required: (value: any) => !!value || "Champ requis.",
        min: (v: string | any[]) => v.length >= 5 || "Min 5 characters"
      },
      text: "",

      snackbar: false
    };
  },

  mounted() {
    axios
      .get(this.url)
      .then(response => {
        this.posts = response.data;
      })
      .catch(e => {
        this.errors.push();
      });
  },
  watch: {
    componentKey: function() {
      axios
        .get(this.url)
        .then(response => {
          this.posts = response.data;
        })
        .catch(e => {
          this.errors.push();
        });
    }
  },
  methods: {
    openDialog(value: any) {
      this.id = value.IdEmployee;
      console.log(value);
    },
    save: function(value: any) {
      //      this.$emit(`update:${key}`, value);
      axios
        .put(`https://localhost:44380/api/User/${value.IdEmployee}`, {
          IdEmployee: this.id,
          Pseudo: this.login,
          Password: this.password
        })
        .then(resp => {
          this.componentKey++;
          this.dialog = false;
          this.text = "Modification enregistrée ";
          this.snackbar = true;

          //    resolve(resp)
        })

        .catch(function(error) {
          console.log(error);
        });
    },
    
    supprimer: function(value: any, i: number) {
      //      this.$emit(`update:${key}`, value);

      axios
        .delete(`https://localhost:44380/api/User/${value.IdEmployee}`)
        .then(resp => {
          this.componentKey++;
          this.text = "Utilisateur " + value.Pseudo + " supprimé";

          this.snackbar = true;
          console.log(i);

          //    resolve(resp)
        })

        .catch(function(error) {
          console.log(error);
        });
    }
  }
});
</script>