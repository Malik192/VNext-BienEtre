<template>
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
                            <v-text-field
                              label="groupe"
                              v-model="groupe"
                             
                              color="#4d8c05"
                              height="40"
                              name="groupe"
                              type="text"
                            ></v-text-field>
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
                      v-model="text"
                      class="form-control"
                      auto-grow
                      color="#4d8c05"
                      label="Citation"
                      prepend-inner-icon="speaker_notes"
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
</template>
