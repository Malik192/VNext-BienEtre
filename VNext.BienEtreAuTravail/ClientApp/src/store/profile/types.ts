import { User } from '../types/User';
import { Quotes } from '../types/Quotes';


export interface ProfileState {
    user?: User;
    quotes?:Quotes;
    IsConnected:boolean;
     Pseudo: string;


    error: boolean;
};
export interface RootState {
     
  version: string;
};