﻿namespace dnYara.Interop
{
    public class Constants
    {
        public const int CHAR_BIT = 8;

        public const int YR_MAX_THREADS = 32;
        public const int tidx_mask_size = (((YR_MAX_THREADS) + (CHAR_BIT - 1)) / CHAR_BIT);

        public const int YR_MAX_LOOP_NESTING  = 4;
        public const int YR_MAX_INCLUDE_DEPTH = 16;


        public const int YR_MAX_COMPILER_ERROR_EXTRA_INFO = 256;
        public const int YR_LEX_BUF_SIZE = 8192;
        public const int MAX_PATH = 260;

        public const int CALLBACK_CONTINUE = 0;
        public const int CALLBACK_ABORT    = 1;
        public const int CALLBACK_ERROR    = 2;

        public const int SCAN_FLAGS_FAST_MODE      = 1;
        public const int SCAN_FLAGS_PROCESS_MEMORY = 2;
        public const int SCAN_FLAGS_NO_TRYCATCH    = 4;

        public const int CALLBACK_MSG_RULE_MATCHING     = 1;
        public const int CALLBACK_MSG_RULE_NOT_MATCHING = 2;
        public const int CALLBACK_MSG_SCAN_FINISHED     = 3;
        public const int CALLBACK_MSG_IMPORT_MODULE     = 4;
        public const int CALLBACK_MSG_MODULE_IMPORTED   = 5;
    }
}