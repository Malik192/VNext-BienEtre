<template >
  <div class="App">
    <h1 class="subheading grey--text">Citations</h1>
    <v-container class="my-5">
      <v-content>
        <v-layout row wrap>
          <v-flex xs12 sm6 md4 lg4 v-for="(post,i) in posts" v-model="posts" v-bind:key="i">
            <v-card flat class="text-xs-center ma-3" elevation="5" v-bind:key="componentKey">
              <v-card-text>
                <div class="subheading">
                  <B>{{ post.Groupe }}</B>
                </div>
              </v-card-text>
              <v-card-text>
                <div class="subheading">{{post.Auteur}}</div>
              </v-card-text>

              <v-card-actions>
                <v-dialog v-model="Edit" persistent max-width="600px">
                  <template v-slot:activator="{ on }">
                    <v-row align="center" justify="center">
                      <v-btn
                        text
                        color="grey"
                        style="margin-left:0px ;min-width:0px"
                        @click="openDialog(post)"
                        v-on="on"
                      >
                        <v-icon small left color="#1DB954">message</v-icon>
                        <span>Voir la citation</span>
                      </v-btn>
                    </v-row>
                  </template>

                  <v-card>
                    <v-card-title>
                      <span class="headline">{{quote.Auteur}}</span>
                    </v-card-title>

                    <v-card-title>
                      <span class="form-control">{{quote.Citation}}</span>
                    </v-card-title>

                    <v-card-text>
                      <v-container>
                        <v-row hidden>
                          <v-col cols="12" sm="6">
                            <v-autocomplete></v-autocomplete>
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card-text>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-row align="center">
                        <v-btn color="#6DB041" text @click="Edit = false">
                          <v-icon large right>cancel</v-icon>
                        </v-btn>
                      </v-row>
                    </v-card-actions>
                  </v-card>
                </v-dialog>

                <v-spacer></v-spacer>

                <v-btn
                  text
                  color="grey"
                  style="margin-left:0px ;min-width:0px"
                  @click="deleteQuotes(post, i)"
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
          <v-dialog v-model="dialog" persistent max-width="600px">
            <template v-slot:activator="{ on }">
              <v-row align="center" justify="center">
                <v-btn text color="grey" style="margin-left:0px ;min-width:0px" v-on="on">
                  <v-icon x-large left color="pink">add_circle</v-icon>
                </v-btn>
              </v-row>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">Citation</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="12" md="12">
                      <v-text-field
                        label="Famille de mots"
                        v-model="Famille_de_mot"
                        color="#4d8c05"
                        height="40"
                        name="Famille_de_mot"
                        type="text"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="12" md="12">
                      <v-select
                        :items="items"
                        v-model="groupe"
                        height="40"
                        label="groupe"
                        name="groupe"
                        color="#4d8c05"
                        :menu-props="{ top: true, offsetY: true }"
                      ></v-select>
                    </v-col>
                    <v-col>
                      <v-text-field
                        label="Auteur"
                        v-model="Auteur"
                        color="#4d8c05"
                        height="40"
                        name="Auteur"
                        type="text"
                      ></v-text-field>
                    </v-col>
                    <v-flex xs12>
                      <v-card class="white--text" elevation="0">
                        <v-card-title primary-title>
                          <v-textarea
                            v-model="Citation"
                            class="form-control"
                            auto-grow
                            color="#4d8c05"
                            label="Citation"
                            name="Citation"
                            rows="1"
                          ></v-textarea>
                        </v-card-title>
                      </v-card>
                    </v-flex>

                    <v-col cols="12" sm="6">
                      <v-autocomplete></v-autocomplete>
                    </v-col>
                  </v-row>
                </v-container>
                <small>*Ajout d'une nouvelle citation</small>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="#6DB041" text @click="dialog = false">
                  <v-icon large right>cancel</v-icon>
                </v-btn>
                <v-btn color="#6DB041" text @click="saveQuote()">
                  <v-icon large right>done</v-icon>
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-layout>
      </v-content>
    </v-container>
  </div>
</template>

<script src="./Quotes.ts"  lang="ts">
</script>
<style>
.text {
  color: #4d8c05;
}
.v-card__text,
.v-card__title {
  word-break: normal; /* maybe !important  */
}
.formfield * {
  vertical-align: middle;
}
</style>