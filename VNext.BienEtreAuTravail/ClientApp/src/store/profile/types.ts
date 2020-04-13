import { User } from '../types/User';
import { Quotes } from '../types/Quote';


export interface ProfileState {
    user?: User;
    quotes?:Quotes;
  
    IsConnected:boolean;
    IsAdmin: boolean;
     Pseudo: string;


    error: boolean;
};
export interface RootState {
     
  version: string;
};