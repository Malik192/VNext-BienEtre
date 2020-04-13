<template>
  <v-card class="mx-auto">
    <v-container>
      <v-row dense>
        <v-col cols="12">
          <router-link class="view two" to="QuotesList">
            <v-card color="#1F7087" dark>
              <div class="d-flex flex-no-wrap justify-space-between">
                <div>
                  <v-card-title class="headline">
                    <p>Citations</p>
                  </v-card-title>

                  <v-card-subtitle>
                    <p>Gerer les citations</p>
                  </v-card-subtitle>
                </div>

                <v-avatar class="ma-3" size="125" tile>
                  <v-img src="@/assets/quotes.png"></v-img>
                </v-avatar>
              </div>
            </v-card>
          </router-link>
        </v-col>
      </v-row>
      <v-row dense>
        <v-col cols="12">
          <router-link class="view two" to="users">
            <v-card color="#952175" dark>
              <div class="d-flex flex-no-wrap justify-space-between">
                <div>
                  <v-card-title class="headline">Utilisateurs</v-card-title>
                  <v-card-subtitle>
                    <p>Gerer les utilisateurs</p>
                  </v-card-subtitle>
                </div>

                <v-avatar class="ma-3" size="125" tile>
                  <v-img src="@/assets/members.png"></v-img>
                </v-avatar>
              </div>
            </v-card>
          </router-link>
          <v-row dense>
            <v-col cols="12">
              <router-link class="view two" to="QuotesList">
                <v-card color="#1F7087" dark>
                  <div class="d-flex flex-no-wrap justify-space-between">
                    <div>
                      <v-card-title class="headline">
                        <p>Graphes</p>
                      </v-card-title>

                      <v-card-subtitle>
                        <p>interpretation des resultats</p>
                      </v-card-subtitle>
                    </div>

                    <v-avatar class="ma-3" size="125" tile>
                      <v-img src="@/assets/graphic-chart.png"></v-img>
                    </v-avatar>
                  </div>
                </v-card>
              </router-link>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>
 