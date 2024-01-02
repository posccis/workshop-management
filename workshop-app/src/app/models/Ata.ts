import { Colaborador } from "./Colaborador";
import { Workshop } from "./Workshop";

export interface Ata {
  id: number;
  workshop: Workshop;
  colaboradores: Colaborador[];
}