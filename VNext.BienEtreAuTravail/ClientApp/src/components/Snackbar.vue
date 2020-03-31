<v-snackbar v-model="snackbar">
            {{ text }}
            <v-btn color="#1DB954" text @click="snackbar = false">
              <v-icon medium right>cancel</v-icon>
            </v-btn>
          </v-snackbar>